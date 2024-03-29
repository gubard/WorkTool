﻿namespace WorkTool.Core.Modules.Common.Extensions;

public static class ObjectExtension
{
    public static T[] AsArray<T>(this T obj)
    {
        return new[] { obj };
    }

    public static void ThrowDisposedException<T>(this T obj) where T : notnull
    {
        throw new ObjectDisposedException<T>(obj);
    }

    public static T ThrowIfIsNot<T>(this object obj)
    {
        if (obj is not T result)
        {
            throw new TypeInvalidCastException(typeof(T), obj.GetType());
        }

        return result;
    }

    public static T ThrowIfIsNotCast<T>(this object obj)
    {
        return (T)obj;
    }

    public static T? As<T>(this object value) where T : class
    {
        return value as T;
    }

    public static T To<T>(this object value)
    {
        return (T)value;
    }

    public static T ThrowIfNull<T>(
        this T? obj,
        [CallerArgumentExpression(nameof(obj))] string paramName = ""
    )
    {
        if (obj is null)
        {
            throw new ArgumentNullException(paramName);
        }

        return obj;
    }

    public static T ThrowIfNullStruct<T>(
        this T? obj,
        [CallerArgumentExpression(nameof(obj))] string paramName = ""
    ) where T : struct
    {
        return obj ?? throw new ArgumentNullException(paramName);
    }

    public static TObj ThrowIfNotEquals<TObj>(this TObj obj, TObj expected, string name)
        where TObj : notnull
    {
        if (obj.Equals(expected))
        {
            return obj;
        }

        throw new NotEqualsException<TObj>(name, obj, expected);
    }

    public static T IfNullUse<T>(this T? obj, T @default)
    {
        if (obj is null)
        {
            return @default;
        }

        return obj;
    }
}
