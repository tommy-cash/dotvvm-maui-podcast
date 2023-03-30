using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DotNetPodcasts.Persistence.Entities;

[Table("Podcasts")]
public class PodcastEntity : Entity
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSubscribed { get; set; }
    public string Description { get; set; }

    [OneToMany]
    public List<EpisodeEntity> Episodes { get; set; }

    [ManyToMany(typeof(PodcastTagRelation))]
    public List<TagEntity> Tags { get; set; }
}