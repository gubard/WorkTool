﻿namespace WorkTool.Core.Modules.ModularSystem.Extensions;

public static class ModuleTreeExtension
{
    public static T GetObject<T>(this IModule module)
    {
        return module.GetObject(typeof(T)).ThrowIfIsNot<T>();
    }
}
