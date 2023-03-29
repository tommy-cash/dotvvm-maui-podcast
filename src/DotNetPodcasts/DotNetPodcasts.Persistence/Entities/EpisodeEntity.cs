using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DotNetPodcasts.Persistence.Entities;

[Table("Episodes")]
public class EpisodeEntity : Entity
{
    public string Name { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Description { get; set; }
    public bool IsSaved { get; set; }
    public string MediaUrl { get; set; }
    public int TotalMinutes { get; set; }

    [ForeignKey(typeof(PodcastEntity))]
    public int PodcastId { get; set; }
}