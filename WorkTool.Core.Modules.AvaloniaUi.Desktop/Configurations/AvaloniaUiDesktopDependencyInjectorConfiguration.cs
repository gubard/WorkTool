namespace WorkTool.Core.Modules.AvaloniaUi.Configurations;

public readonly struct AvaloniaUiDesktopDependencyInjectorConfiguration
    : IDependencyInjectorConfiguration
{
    public void Configure(IDependencyInjectorRegister register)
    {
        register.RegisterTransient<AvaloniaUiApplication, DesktopAvaloniaUiApplication>();

        register.RegisterTransient<AppBuilder>(
            (AvaloniaUiApp avaloniaUiApp) =>
                AppBuilder.Configure(() => avaloniaUiApp).UseReactiveUI().UsePlatformDetect()
        );
    }
}
