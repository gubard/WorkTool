﻿namespace WorkTool.Core.Modules.ReactiveUI.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected readonly IHumanizing<Exception, object> Humanizing;
    protected readonly IMessageBoxView MessageBoxView;
    protected readonly IScheduler Scheduler;
    protected readonly IInvoker Invoker;

    public ReplaySubject<bool> CanExecute { get; }

    public ViewModelBase(
        IScheduler scheduler,
        IHumanizing<Exception, object> humanizing,
        IMessageBoxView messageBoxView,
        IInvoker invoker
    )
    {
        Scheduler = scheduler;
        Invoker = invoker;
        Humanizing = humanizing.ThrowIfNull();
        MessageBoxView = messageBoxView.ThrowIfNull();
        CanExecute = new ReplaySubject<bool>(1);
        CanExecute.OnNext(true);
    }

    public ReactiveCommand<Unit, Unit> CreateCommand(Delegate del)
    {
        return CreateCommand(async () =>
        {
            var result = Invoker.Invoke(del, new DictionarySpan<TypeInformation, object>());

            if (result is null)
            {
                return;
            }

            if (result is Task task)
            {
                await task;
            }
        });
    }

    public ReactiveCommand<TValue, Unit> CreateCommand<TValue>(Action<TValue> action)
    {
        var command = ReactiveCommand.CreateFromTask(CreateAction(action), CanExecute, Scheduler);
        command.ThrownExceptions.Subscribe(x => ShowExceptionAsync(x));

        return command;
    }

    public ReactiveCommand<TValue, Unit> CreateCommand<TValue>(Func<TValue, Task> func)
    {
        var command = ReactiveCommand.CreateFromTask(CreateFunc(func), CanExecute, Scheduler);
        command.ThrownExceptions.Subscribe(x => ShowExceptionAsync(x));

        return command;
    }

    public ReactiveCommand<Unit, Unit> CreateCommand(Action action)
    {
        var command = ReactiveCommand.CreateFromTask(CreateAction(action), CanExecute, Scheduler);
        command.ThrownExceptions.Subscribe(x => ShowExceptionAsync(x));

        return command;
    }

    public ReactiveCommand<Unit, Unit> CreateCommand(Func<Task> func, IScheduler outputScheduler)
    {
        var command = ReactiveCommand.CreateFromTask(
            CreateFunc(func),
            CanExecute,
            outputScheduler: outputScheduler
        );

        command.ThrownExceptions.Subscribe(x => ShowExceptionAsync(x));

        return command;
    }

    public ReactiveCommand<Unit, Unit> CreateCommand(Func<Task> func)
    {
        var command = ReactiveCommand.CreateFromTask(CreateFunc(func), CanExecute, Scheduler);
        command.ThrownExceptions.Subscribe(x => ShowExceptionAsync(x));

        return command;
    }

    private Task ShowExceptionAsync(Exception exception)
    {
        Console.WriteLine(exception);
        var view = Humanizing.Humanize(exception);

        return MessageBoxView.ShowErrorAsync(view);
    }

    protected Func<Task> CreateAction(Action action)
    {
        return async () =>
        {
            CanExecute.OnNext(false);

            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                await ShowExceptionAsync(exception);
            }
            finally
            {
                CanExecute.OnNext(true);
            }
        };
    }

    protected Func<TValue, Task> CreateAction<TValue>(Action<TValue> action)
    {
        return async value =>
        {
            CanExecute.OnNext(false);

            try
            {
                action.Invoke(value);
            }
            catch (Exception exception)
            {
                await ShowExceptionAsync(exception);
            }
            finally
            {
                CanExecute.OnNext(true);
            }
        };
    }

    protected Func<Task> CreateFunc(Func<Task> func)
    {
        return async () =>
        {
            CanExecute.OnNext(false);

            try
            {
                await func.Invoke();
            }
            catch (Exception exception)
            {
                await ShowExceptionAsync(exception);
            }
            finally
            {
                CanExecute.OnNext(true);
            }
        };
    }

    protected Func<TValue, Task> CreateFunc<TValue>(Func<TValue, Task> func)
    {
        return async value =>
        {
            CanExecute.OnNext(false);

            try
            {
                await func.Invoke(value);
            }
            catch (Exception exception)
            {
                await ShowExceptionAsync(exception);
            }
            finally
            {
                CanExecute.OnNext(true);
            }
        };
    }
}
