using DotVVM.Framework.Hosting;

namespace DotNetPodcasts.App.Web.Config
{
    public static class ResourceManagerExtensions
    {
        public static void TryAddRequiredResource(this IDotvvmRequestContext context, string moduleCssResourceName)
        {
            if (context.Configuration.Resources.Resources.ContainsKey(moduleCssResourceName))
            {
                context.ResourceManager.AddRequiredResource(moduleCssResourceName);
            }
        }
    }
}
