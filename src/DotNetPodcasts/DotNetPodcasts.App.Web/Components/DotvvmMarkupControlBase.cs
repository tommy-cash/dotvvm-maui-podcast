using System.IO;
using System.Linq;
using DotNetPodcasts.App.Web.Config;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotNetPodcasts.App.Web.Components;

public class DotvvmMarkupControlBase : DotvvmMarkupControl
{
    protected override void OnInit(IDotvvmRequestContext context)
    {
        var controlName = GetType().Name;
        var controlPath = context.Configuration.Markup.Controls.Single(c => c.TagName?.Equals(controlName) ?? false).Src;
        var virtualPath = Path.GetRelativePath(context.Configuration.ApplicationPhysicalPath, controlPath);

        virtualPath = Path.ChangeExtension(virtualPath, string.Empty);
        if (controlName != null)
        {
            var resourceName = virtualPath.Substring(0, virtualPath.LastIndexOf('.')).Replace("\\", "_").Replace("/", "_");
            context.TryAddRequiredResource($"{resourceName}-css");
            context.TryAddRequiredResource(resourceName);
            base.OnInit(context);
        }
    }
}