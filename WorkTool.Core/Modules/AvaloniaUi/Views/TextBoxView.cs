﻿namespace WorkTool.Core.Modules.AvaloniaUi.Views;

public class TextBoxView : ReactiveTextBox<ViewModelBase>, IContextMenuView, ISetParameter
{
    private readonly IInvoker invoker;
    private readonly Dictionary<TypeInformation, object> parameters;

    public TextBoxView(IInvoker invoker, UiContext avaloniaUiContext, ViewModelBase viewModel)
    {
        parameters = new() { { GetType(), this } };
        DataContext = viewModel;
        this.invoker = invoker.ThrowIfNull();
        this.WhenActivated(_ => { });
        avaloniaUiContext.InitView(this);
    }

    public void AddMenuItem(TreeNode<string, MenuItemContext> node)
    {
        if (ContextFlyout is null)
        {
            var menuFlyout = new MenuFlyout();

            menuFlyout
                .AddItem(
                    new MenuItem()
                        .SetHeader("Cut")
                        .SetCommand(ReactiveCommand.Create(Cut))
                        .BindValue(
                            IsEnabledProperty,
                            new Binding("CanCut").SetRelativeSource(
                                new RelativeSource(
                                    RelativeSourceMode.TemplatedParent
                                ).SetAncestorType(typeof(TextBox))
                            )
                        )
                )
                .AddItem(
                    new MenuItem()
                        .SetHeader("Copy")
                        .SetCommand(ReactiveCommand.Create(Copy))
                        .BindValue(
                            IsEnabledProperty,
                            new Binding("CanCopy").SetRelativeSource(
                                new RelativeSource(
                                    RelativeSourceMode.TemplatedParent
                                ).SetAncestorType(typeof(TextBox))
                            )
                        )
                )
                .AddItem(
                    new MenuItem()
                        .SetHeader("Paste")
                        .SetCommand(ReactiveCommand.Create(Paste))
                        .BindValue(
                            IsEnabledProperty,
                            new Binding("CanPaste").SetRelativeSource(
                                new RelativeSource(
                                    RelativeSourceMode.TemplatedParent
                                ).SetAncestorType(typeof(TextBox))
                            )
                        )
                );

            ContextFlyout = menuFlyout;
        }

        var menuItem = ToMenuItem(node);

        if (ContextFlyout is not MenuFlyout contextFlyout)
        {
            throw new TypeInvalidCastException(typeof(MenuFlyout), ContextFlyout.GetType());
        }

        contextFlyout.AddItem(menuItem);
    }

    public void SetParameter(Type type, object obj)
    {
        parameters[type] = obj;
    }

    private MenuItem ToMenuItem(TreeNode<string, MenuItemContext> node)
    {
        return AddHeader(AddCommand(new MenuItem(), node), node)
            .SetItems(node.Nodes.Select(x => ToMenuItem(x)).ToArray());
    }

    private MenuItem AddHeader(MenuItem menuItem, TreeNode<string, MenuItemContext> node)
    {
        switch (node.Value)
        {
            default:
            {
                menuItem.SetHeader(node.Value.Header.Invoke());

                break;
            }
        }

        return menuItem;
    }

    private MenuItem AddCommand(MenuItem menuItem, TreeNode<string, MenuItemContext> node)
    {
        var currentViewModel = ViewModel.ThrowIfNull();

        var command = currentViewModel.CreateCommand(
            (Action)(
                async () =>
                {
                    var @delegate = node.Value.Task.ThrowIfNull();
                    var result = invoker.Invoke(@delegate, parameters);

                    if (result is Task task)
                    {
                        await task;
                    }
                }
            )
        );

        return menuItem.SetCommand(command);
    }
}
