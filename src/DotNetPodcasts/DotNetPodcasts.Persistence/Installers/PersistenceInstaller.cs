using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Entities;
using DotNetPodcasts.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetPodcasts.Persistence.Installers;

public static class PersistenceInstaller
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IRepository<PodcastEntity>, PodcastRepository>()
            .AddSingleton<IRepository<EpisodeEntity>, EpisodeRepository>()
            .AddSingleton<IRepository<TagEntity>, TagRepository>()
            .AddTransient<Seeder>();
    }
}