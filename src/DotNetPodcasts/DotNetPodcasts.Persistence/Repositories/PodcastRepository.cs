using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.Persistence.Repositories;

public class PodcastRepository : RepositoryBase<PodcastEntity>
{
    public PodcastRepository(DatabaseConfiguration databaseConfiguration) 
        : base(databaseConfiguration)
    {
    }

    protected override void Init()
    {
        base.Init();
        Database.CreateTable<PodcastTagRelation>();
    }
}