namespace DotNetPodcasts.App.Maui.HostedApp.Models;

public class EpisodeListModel : ModelBase
{
    public string Name { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Description { get; set; }
    public bool IsSaved { get; set; }
    public string MediaUrl { get; set; }
    public int TotalMinutes { get; set; }
}