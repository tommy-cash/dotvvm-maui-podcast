using DotNetPodcasts.App.Maui.HostedApp.Components.Episode;
using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;

namespace DotNetPodcasts.App.Maui.HostedApp.Installers;

public static class ComponentServiceCollectionExtensions
{
    public static IServiceCollection AddComponentViewModels(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<EpisodePlayerViewModel>()
            .AddSingleton<EpisodeViewModel>();
    }
}