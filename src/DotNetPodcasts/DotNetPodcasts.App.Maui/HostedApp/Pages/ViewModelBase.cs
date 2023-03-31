using DotNetPodcasts.App.Maui.HostedApp.Config;
using DotVVM.Framework.ViewModel;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages;

public class ViewModelBase : DotvvmViewModelBase
{
    public string CurrentRoute => Context.Route.RouteName;

    public override async Task Init()
    {
        await base.Init();

        var virtualPath = Context.Route?.VirtualPath;
        if (virtualPath != null)
        {
            var resourceName = virtualPath.Substring(0, virtualPath.LastIndexOf('.')).Replace("/", "_");
            Context.TryAddRequiredResource($"{resourceName}-css");
            Context.TryAddRequiredResource(resourceName);
        }
    }
}