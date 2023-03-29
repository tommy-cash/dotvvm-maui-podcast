using DotNetPodcasts.Persistence.Configuration;
using DotNetPodcasts.Persistence.Entities;

namespace DotNetPodcasts.Persistence.Repositories;

public class TagRepository : RepositoryBase<TagEntity>
{
    public TagRepository(DatabaseConfiguration databaseConfiguration) 
        : base(databaseConfiguration)
    {
    }

    protected override void Init()
    {
        base.Init();
        Database.CreateTable<PodcastTagRelation>();
    }
}