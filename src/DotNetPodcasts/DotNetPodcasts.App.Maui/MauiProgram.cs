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

        var path = Path.GetDirectoryName(typeof(MauiProgram).Assembly.Location);
        while (!Directory.GetFiles(path, "*.csproj").Any())
        {
            if (path == Path.GetDirectoryName(path))
            {
                throw new Exception("Csproj file not found anywhere on the application path.");
            }
            path = Path.GetDirectoryName(path);
        }
        var webRootPath = Path.Combine(path, "HostedApp/wwwroot");
        var applicationPath = Path.Combine(path, "HostedApp");

        builder.AddMauiDotvvmWebView<DotvvmStartup>(applicationPath, webRootPath, debug: true, configure:
            config => {
                config.Markup.ViewCompilation.Mode = DotVVM.Framework.Compilation.ViewCompilationMode.Lazy;
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var mauiApp = builder.Build();

        InstanceHolder.WebViewMessageHandler = mauiApp.Services.GetService<WebViewMessageHandler>();
        
        return mauiApp;
	}
}
