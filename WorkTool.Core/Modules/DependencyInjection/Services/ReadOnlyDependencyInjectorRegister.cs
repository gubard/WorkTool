﻿namespace WorkTool.Core.Modules.DependencyInjection.Services;

public class ReadOnlyDependencyInjectorRegister
    : IBuilder<DependencyInjector>,
        IDependencyInjectorRegister
{
    private readonly Dictionary<AutoInjectMemberIdentifier, InjectorItem> autoInjectMembers;
    private readonly Dictionary<
        ReservedCtorParameterIdentifier,
        InjectorItem
    > reservedCtorParameters;
    private readonly Dictionary<TypeInformation, InjectorItem> injectors;

    public ReadOnlyDependencyInjectorRegister()
    {
        reservedCtorParameters = new();
        injectors = new();
        autoInjectMembers = new();
    }

    public void RegisterConfiguration(IDependencyInjectorConfiguration configuration)
    {
        configuration.Configure(this);
    }

    public DependencyInjector Build()
    {
        var dependencyInjector = new DependencyInjector(
            injectors,
            autoInjectMembers,
            reservedCtorParameters
        );

        return dependencyInjector;
    }

    public void RegisterTransient(Type type, Expression expression)
    {
        RegisterTransientCore(type, expression);
    }

    public void RegisterSingleton(Type type, Expression expression)
    {
        RegisterSingletonCore(type, expression);
    }

    public void RegisterTransientAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Transient, expression);
        autoInjectMembers[memberIdentifier] = injectorItem;
    }

    public void RegisterSingletonAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Singleton, expression);
        autoInjectMembers[memberIdentifier] = injectorItem;
    }

    private void RegisterTransientCore(Type type, Expression expression)
    {
        injectors[type] = new InjectorItem(InjectorItemType.Transient, expression);
    }

    public void RegisterSingletonCore(Type type, Expression expression)
    {
        injectors[type] = new InjectorItem(InjectorItemType.Singleton, expression);
    }

    public void RegisterSingletonReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Singleton, expression);
        reservedCtorParameters[identifier] = injectorItem;
    }

    public void RegisterTransientReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Transient, expression);
        reservedCtorParameters[identifier] = injectorItem;
    }
}
