using DotNetPodcasts.App.Maui.HostedApp.Routing;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ResourceManagement;

namespace DotNetPodcasts.App.Maui;

public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
{
    public List<string> ControlPaths = new()
    {
        "Components/Episode/Episode",
        "Components/EpisodePlayer/EpisodePlayer",
        "Components/Icons/Icon/Icon",
        "Components/Icons/IconSet/IconSet",
        "Components/PodcastCard/PodcastCard"
    };

    public void Configure(DotvvmConfiguration config, string applicationPath)
    {
        ConfigureRoutes(config, applicationPath);
        ConfigureControls(config, applicationPath);
        ConfigureResources(config, applicationPath);
        config.Markup.ViewCompilation.Mode = ViewCompilationMode.Lazy;
        config.DefaultCulture = "cs";
    }

    private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
    {
        var routeTableProvider = new RouteTableProvider();
        routeTableProvider.ConfigureRoutes(config.RouteTable);
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
        foreach (var controlPath in ControlPaths)
        {
            var controlName = Path.GetFileName(controlPath);

            config.Markup.AddMarkupControl("cc", controlName, controlPath + ".dotcontrol");
            
            // register css and js
            ConfigureResourcesIfExist(config, controlPath);
        }
    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
        config.Resources.RegisterStylesheet("style-css", new UrlResourceLocation("~/WebResources/Resources/Styles/Styles.css"));

        config.Resources.RegisterScript("app-js", new UrlResourceLocation("~/WebResources/Resources/Scripts/Scripts.js"));

        foreach (var viewPath in config.RouteTable.Select(x => Path.ChangeExtension(x.VirtualPath, null)))
        {
            ConfigureResourcesIfExist(config, viewPath);
        }
    }

    private void ConfigureResourcesIfExist(DotvvmConfiguration config, string path)
    {
        var fileProvider = config.ServiceProvider.GetService<IDotvvmFileProvider>();

        var controlResourceName = path.Replace("\\", "_").Replace("/", "_");

        var resourcePath = Path.Combine("WebResources", path);
        var cssPath = resourcePath + ".css";
        var jsPath = resourcePath + ".js";

        if (fileProvider.FileExistsAsync(cssPath).Result)
        {
            config.Resources.RegisterStylesheet(controlResourceName + "-css", new UrlResourceLocation($"~/{cssPath}"));
        }

        if (fileProvider.FileExistsAsync(jsPath).Result)
        {
            config.Resources.Register(controlResourceName, new ScriptModuleResource(new UrlResourceLocation($"~/{jsPath}")){ Dependencies = new[] { ResourceConstants.DotvvmResourceName }});
        }
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        options.AddDefaultTempStorages("temp");
    }
}