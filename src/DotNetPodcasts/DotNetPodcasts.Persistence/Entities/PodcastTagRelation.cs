using SQLiteNetExtensions.Attributes;

namespace DotNetPodcasts.Persistence.Entities;

public class PodcastTagRelation
{
    [ForeignKey(typeof(PodcastEntity))]
    public int PodcastId { get; set; }

    [ForeignKey(typeof(TagEntity))]
    public int TagId { get; set; }
}