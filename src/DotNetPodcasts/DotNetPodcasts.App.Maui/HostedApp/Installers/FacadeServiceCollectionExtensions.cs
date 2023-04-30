using DotNetPodcasts.App.Maui.HostedApp.Facades;

namespace DotNetPodcasts.App.Maui.HostedApp.Installers;

public static class FacadeServiceCollectionExtensions
{
    public static IServiceCollection AddFacades(this IServiceCollection services)
    {
        return services
            .AddTransient<PodcastFacade>()
            .AddTransient<EpisodeFacade>();
    }
}