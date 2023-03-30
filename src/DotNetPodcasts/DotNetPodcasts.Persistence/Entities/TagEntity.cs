using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DotNetPodcasts.Persistence.Entities;

[Table("Tags")]
public class TagEntity : Entity
{
    public string Name { get; set; }

    [ManyToMany(typeof(PodcastTagRelation))]
    public List<PodcastEntity> Podcasts { get; set; }
}