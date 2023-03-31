using DotNetPodcasts.App.Maui.HostedApp.Config;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotNetPodcasts.App.Maui.HostedApp.Components;

public class DotvvmMarkupControlBase : DotvvmMarkupControl
{
    protected override void OnInit(IDotvvmRequestContext context)
    {
        var controlName = GetType().Name;
        var controlPath = context.Configuration.Markup.Controls.Single(c => c.TagName?.Equals(controlName) ?? false).Src;

        controlPath = Path.ChangeExtension(controlPath, null);
        if (controlPath != null)
        {
            var resourceName = controlPath.Replace("\\", "_").Replace("/", "_");
            context.TryAddRequiredResource($"{resourceName}-css");
            context.TryAddRequiredResource(resourceName);
            base.OnInit(context);
        }
    }
}