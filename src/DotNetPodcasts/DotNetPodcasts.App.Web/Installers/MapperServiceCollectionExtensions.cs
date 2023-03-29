using DotNetPodcasts.App.Web.Mappers;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.Persistence.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPodcasts.App.Web.Installers;

public static class MapperServiceCollectionExtensions
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMapper<PodcastEntity, PodcastDetailModel, PodcastListModel>, PodcastMapper>()
            .AddTransient<IMapper<EpisodeEntity, EpisodeDetailModel, EpisodeListModel>, EpisodeMapper>();
    }
}