namespace WorkTool.Core.Modules.DependencyInjection.Models;

public readonly record struct AutoInjectIdentifier(Type Type, MemberInfo Property);
