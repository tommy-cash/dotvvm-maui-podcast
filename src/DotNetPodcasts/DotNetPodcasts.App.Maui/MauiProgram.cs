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
        //var applicationPath = Path.Combine("HostedApp");

        CopyViews(applicationPath);

        builder.AddMauiDotvvmWebView<DotvvmStartup>(applicationPath, webRootPath, debug: true, configure:
            config => {
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

    public static void CopyViews(string applicationPath)
    {
        var viewPaths = new List<string>()
        {
            "Pages/Default/Default.dothtml",
            "Pages/MasterPage.dotmaster"
        };

        foreach (var viewPath in viewPaths)
        {
            var viewExists = FileSystem.AppPackageFileExistsAsync(viewPath).Result;

            var page = FileSystem.OpenAppPackageFileAsync(viewPath).Result;
            using var reader = new StreamReader(page);
            var content = reader.ReadToEnd();
            
            var dirPath = Path.GetDirectoryName(viewPath);
            var appDataDirPath = Path.Combine(applicationPath, dirPath);
            Directory.CreateDirectory(appDataDirPath);

            var appDataViewPath = Path.Combine(applicationPath, viewPath);

            using FileStream outputStream = System.IO.File.OpenWrite(appDataViewPath);
            using StreamWriter streamWriter = new StreamWriter(outputStream);

            streamWriter.Write(content);
        }

        foreach (var appDataViewPath in viewPaths.Select(x => Path.Combine(applicationPath, x)))
        {
            // check if views exist
            var result = File.Exists(appDataViewPath);
        }
    }
}
