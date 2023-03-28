using DotNetPodcasts.App.Web.Components.PodcastPlayer;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPodcasts.App.Web.Installers;

public static class ComponentServiceCollectionExtensions
{
    public static IServiceCollection AddComponentViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<PodcastPlayerViewModel>();

        return serviceCollection;
    }
}