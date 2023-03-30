using DotVVM.Framework.Hosting.Maui;
using DotVVM.Framework.Hosting.Maui.Services;
using Microsoft.Extensions.Logging;

namespace DotNetPodcasts.App.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var webRootPath = Path.Combine("HostedApp/wwwroot");
        var applicationPath = FileSystem.AppDataDirectory;

        builder.AddMauiDotvvmWebView<DotvvmStartup>(applicationPath, webRootPath, debug: true, configure:
            config =>
            {
                config.Markup.ViewCompilation.Mode = DotVVM.Framework.Compilation.ViewCompilationMode.Lazy;
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var mauiApp = builder.Build();

        // TODO: remove this workaround
        InstanceHolder.WebViewMessageHandler = mauiApp.Services.GetService<WebViewMessageHandler>();

        return mauiApp;
    }
}
