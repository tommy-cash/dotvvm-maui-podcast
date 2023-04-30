using DotNetPodcasts.App.Maui.HostedApp.Mappers;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.App.Maui.HostedApp.Installers;

public static class MapperServiceCollectionExtensions
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMapper<PodcastEntity, PodcastDetailModel, PodcastListModel>, PodcastMapper>()
            .AddTransient<IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel>, EpisodeMapper>();
    }
}