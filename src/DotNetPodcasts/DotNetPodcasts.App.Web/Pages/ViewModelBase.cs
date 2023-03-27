using System.Threading;
using System.Threading.Tasks;
using DotNetPodcasts.App.Web.Config;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;

namespace DotNetPodcasts.App.Web.Pages;

public class ViewModelBase : DotvvmViewModelBase
{
    protected CancellationToken RequestCancellationToken => Context.GetAspNetCoreContext().RequestAborted;

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

    public string CurrentRoute => Context.Route.RouteName;
}