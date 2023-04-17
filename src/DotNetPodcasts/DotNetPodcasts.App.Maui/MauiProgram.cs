using CommunityToolkit.Maui;
using DotNetPodcasts.App.Maui.HostedApp.Installers;
using DotNetPodcasts.App.Maui.Services;
using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Installers;
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
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var webRootPath = Path.Combine("HostedApp/WebResources");
        var applicationPath = Path.Combine(FileSystem.AppDataDirectory, "HostedApp");

        builder.AddMauiDotvvmWebView<DotvvmStartup>(applicationPath, webRootPath, debug: true, configure:
            config =>
            {
                config.Markup.ViewCompilation.Mode = DotVVM.Framework.Compilation.ViewCompilationMode.Lazy;
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddComponentViewModels();
        builder.Services.AddSingleton(new DatabaseConfiguration
        {
            DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "DotNetPodcasts.db3")
        });
        builder.Services.AddRepositories();
        builder.Services.AddMappers();
        builder.Services.AddFacades();

        var mauiApp = builder.Build();

        // TODO: remove this workaround
        InstanceHolder.WebViewMessageHandler = mauiApp.Services.GetService<WebViewMessageHandler>();

        return mauiApp;
    }
}
