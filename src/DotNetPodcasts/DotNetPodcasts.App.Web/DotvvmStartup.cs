using System;
using System.IO;
using System.Linq;
using DotNetPodcasts.App.Web.Routing;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPodcasts.App.Web;

public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
{
    // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
    public void Configure(DotvvmConfiguration config, string applicationPath)
    {
        ConfigureRoutes(config, applicationPath);
        ConfigureControls(config, applicationPath);
        ConfigureResources(config, applicationPath);
        config.Markup.ViewCompilation.Mode = ViewCompilationMode.DuringApplicationStart;
        config.DefaultCulture = "cs";
    }

    private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
    {
        var routeTableProvider = new RouteTableProvider();
        routeTableProvider.ConfigureRoutes(config.RouteTable);
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
        config.Markup.AutoDiscoverControls(new DefaultControlRegistrationStrategy(config, "cc", "Components"));
        config.Markup.AutoDiscoverControls(new DefaultControlRegistrationStrategy(config, "cc", "Pages"));
    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
        // register custom resources and adjust paths to the built-in resources
        AutoDiscoverResources(config, Path.Combine(config.ApplicationPhysicalPath, "wwwroot"), "wwwroot");
        ConfigureStyleResources(config);
        ConfigureScriptResources(config);
    }

    private void AutoDiscoverResources(DotvvmConfiguration config, string directory, string pathPrefix, string[]? segments = null)
    {
        segments ??= Array.Empty<string>();
        foreach (var entry in new DirectoryInfo(directory).GetFileSystemInfos())
        {
            if (entry is DirectoryInfo)
            {
                // browse directories recursively
                var childSegments = segments.Concat(new[] { entry.Name }).ToArray();
                AutoDiscoverResources(config, entry.FullName, pathPrefix, childSegments);
            }
            else
            {
                // register resource if it has the correct extension
                var resourceName = string.Join("_", segments.Select(s => s.TrimStart('_')).Concat(new[] { Path.GetFileNameWithoutExtension(entry.Name.TrimStart('_')) }));
                var resourcePath = string.Join("/", new[] { pathPrefix.TrimEnd('/') }.Concat(segments).Concat(new[] { entry.Name }));

                if (string.Equals(entry.Extension, ".js", StringComparison.OrdinalIgnoreCase))
                {
                    config.Resources.RegisterScriptModuleFile(resourceName, resourcePath, dependencies: new[] { ResourceConstants.DotvvmResourceName });
                }
                else if (string.Equals(entry.Extension, ".css", StringComparison.OrdinalIgnoreCase))
                {
                    config.Resources.RegisterStylesheetFile(resourceName + "-css", resourcePath);
                }
            }
        }
    }

    private static void ConfigureStyleResources(DotvvmConfiguration config)
    {
        config.Resources.RegisterStylesheetFile("style-css", "wwwroot/Resources/Styles/Styles.css");
    }

    private static void ConfigureScriptResources(DotvvmConfiguration config)
    {
        config.Resources.RegisterScriptModuleFile("app-js", "wwwroot/Resources/Scripts/Scripts.js", defer: true);
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        options.AddHotReload();
        options.AddDefaultTempStorages("temp");
    }
}