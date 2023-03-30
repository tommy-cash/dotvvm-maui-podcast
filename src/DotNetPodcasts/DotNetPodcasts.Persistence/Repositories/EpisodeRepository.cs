using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.Persistence.Repositories;

public class EpisodeRepository : RepositoryBase<EpisodeEntity>
{
    public EpisodeRepository(DatabaseConfiguration databaseConfiguration) 
        : base(databaseConfiguration)
    {
    }
}