﻿namespace WorkTool.Core.Modules.AvaloniaUi.Services;

public class CollectionChangedEventManager
{
    private readonly ConditionalWeakTable<INotifyCollectionChanged, Entry> entries = new();
    public static CollectionChangedEventManager Instance { get; } = new();

    private CollectionChangedEventManager() { }

    public void AddListener(
        INotifyCollectionChanged collection,
        ICollectionChangedListener listener
    )
    {
        collection = collection ?? throw new ArgumentNullException(nameof(collection));
        listener = listener ?? throw new ArgumentNullException(nameof(listener));
        Dispatcher.UIThread.VerifyAccess();

        if (!entries.TryGetValue(collection, out var entry))
        {
            entry = new Entry(collection);
            entries.Add(collection, entry);
        }

        foreach (var l in entry.Listeners)
        {
            if (l.TryGetTarget(out var target) && target == listener)
            {
                throw new InvalidOperationException(
                    "Collection listener already added for this collection/listener combination."
                );
            }
        }

        entry.Listeners.Add(new WeakReference<ICollectionChangedListener>(listener));
    }

    public void RemoveListener(
        INotifyCollectionChanged collection,
        ICollectionChangedListener listener
    )
    {
        collection = collection ?? throw new ArgumentNullException(nameof(collection));
        listener = listener ?? throw new ArgumentNullException(nameof(listener));
        Dispatcher.UIThread.VerifyAccess();

        if (!entries.TryGetValue(collection, out var entry))
        {
            throw new InvalidOperationException(
                "Collection listener not registered for this collection/listener combination."
            );
        }

        var listeners = entry.Listeners;

        for (var i = 0; i < listeners.Count; ++i)
        {
            if (!listeners[i].TryGetTarget(out var target) || target != listener)
            {
                continue;
            }

            listeners.RemoveAt(i);

            if (listeners.Count != 0)
            {
                return;
            }

            entry.Dispose();
            entries.Remove(collection);

            return;
        }

        throw new InvalidOperationException(
            "Collection listener not registered for this collection/listener combination."
        );
    }

    private class Entry : IWeakEventSubscriber<NotifyCollectionChangedEventArgs>, IDisposable
    {
        private readonly INotifyCollectionChanged collection;

        public List<WeakReference<ICollectionChangedListener>> Listeners { get; }

        public Entry(INotifyCollectionChanged collection)
        {
            this.collection = collection;
            Listeners = new List<WeakReference<ICollectionChangedListener>>();
            WeakEvents.CollectionChanged.Subscribe(this.collection, this);
        }

        public void Dispose()
        {
            WeakEvents.CollectionChanged.Unsubscribe(collection, this);
        }

        void IWeakEventSubscriber<NotifyCollectionChangedEventArgs>.OnEvent(
            object? notifyCollectionChanged,
            WeakEvent ev,
            NotifyCollectionChangedEventArgs e
        )
        {
            static void Notify(
                INotifyCollectionChanged incc,
                NotifyCollectionChangedEventArgs args,
                List<WeakReference<ICollectionChangedListener>> listeners
            )
            {
                foreach (var l in listeners)
                {
                    if (l.TryGetTarget(out var target))
                    {
                        target.PreChanged(incc, args);
                    }
                }

                foreach (var l in listeners)
                {
                    if (l.TryGetTarget(out var target))
                    {
                        target.Changed(incc, args);
                    }
                }

                foreach (var l in listeners)
                {
                    if (l.TryGetTarget(out var target))
                    {
                        target.PostChanged(incc, args);
                    }
                }
            }

            var l = Listeners.ToList();

            if (Dispatcher.UIThread.CheckAccess())
            {
                Notify(collection, e, l);
            }
            else
            {
                var eCapture = e;
                Dispatcher.UIThread.Post(() => Notify(collection, eCapture, l));
            }
        }
    }
}
