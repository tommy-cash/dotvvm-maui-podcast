using SQLiteNetExtensions.Attributes;

namespace DotNetPodcasts.Persistence.Entities;

public class PodcastTagRelation
{
    [ForeignKey(typeof(PodcastEntity))]
    public int PersonId { get; set; }

    [ForeignKey(typeof(TagEntity))]
    public int EventId { get; set; }
}