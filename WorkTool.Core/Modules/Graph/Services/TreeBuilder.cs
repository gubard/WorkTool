﻿namespace WorkTool.Core.Modules.Graph.Services;

public class TreeBuilder<TKey, TValue> : IBuilder<Tree<TKey, TValue>> where TKey : notnull
{
    private TreeNodeBuilder<TKey, TValue> root;

    public TreeNodeBuilder<TKey, TValue> Root
    {
        get => root;
        set
        {
            root        = value;
            root.Parent = null;
        }
    }

    public TreeNodeBuilder<TKey, TValue> this[TKey key]
    {
        get
        {
            if (Root is null)
            {
                Root = new TreeNodeBuilder<TKey, TValue>
                {
                    Key = key
                };

                return Root;
            }

            if (Root.Key.Equals(key))
            {
                return Root;
            }

            Root = new TreeNodeBuilder<TKey, TValue>
            {
                Key = key
            };

            return Root;
        }
        set
        {
            Root        = value;
            Root.Parent = null;
            Root.Key    = key;
        }
    }

    public TreeNodeBuilder<TKey, TValue> this[TKey key, TValue defaultValue]
    {
        get
        {
            if (Root is null)
            {
                Root = new TreeNodeBuilder<TKey, TValue>
                {
                    Key   = key,
                    Value = defaultValue
                };

                return Root;
            }

            if (Root.Key.Equals(key))
            {
                return Root;
            }

            Root = new TreeNodeBuilder<TKey, TValue>
            {
                Key   = key,
                Value = defaultValue
            };

            return Root;
        }
    }

    public TreeNodeBuilder<TKey, TValue> this[TValue defaultValue, params TKey[] keys]
    {
        get
        {
            if (keys.Length == 0)
            {
                return Root;
            }

            var currentNode = this[keys[0], defaultValue];

            foreach (var key in keys[1..])
            {
                currentNode = currentNode[key, defaultValue];
            }

            return currentNode;
        }
        set
        {
            if (keys.Length == 0)
            {
                Root = value;

                return;
            }

            if (keys.Length == 1)
            {
                this[keys[0]] = value;

                return;
            }

            var root = this[keys[0], defaultValue];
            root[defaultValue, keys[1..]] = value;
        }
    }

    public TreeNodeBuilder<TKey, TValue> this[params TKey[] keys]
    {
        get
        {
            if (keys.Length == 0)
            {
                return Root;
            }

            var currentNode = this[keys[0]];

            foreach (var key in keys[1..])
            {
                currentNode = currentNode[key];
            }

            return currentNode;
        }
        set
        {
            if (keys.Length == 0)
            {
                Root = value;

                return;
            }

            if (keys.Length == 1)
            {
                this[keys[0]] = value;

                return;
            }

            var root = this[keys[0]];
            root[keys[1..]] = value;
        }
    }

    public Tree<TKey, TValue> Build()
    {
        var root = this.root.Build();

        return new Tree<TKey, TValue>(root);
    }
}