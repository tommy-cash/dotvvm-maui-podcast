using DotNetPodcasts.App.Web.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPodcasts.App.Web.Installers;

public static class FacadeServiceCollectionExtensions
{
    public static IServiceCollection AddFacades(this IServiceCollection services)
    {
        return services
            .AddTransient<PodcastFacade>()
            .AddTransient<EpisodeFacade>();
    }
}