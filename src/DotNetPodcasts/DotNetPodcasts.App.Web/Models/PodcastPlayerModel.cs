namespace DotNetPodcasts.App.Web.Models;

public class PodcastPlayerModel
{
    public string EpisodeName { get; set; } = "Episode name long long long long long long long long long long";
    public string PodcastName { get; set; } = "Podcast name";
    public double ElapsedEpisodeTime { get; set; } = 20;
    public double TotalEpisodeTime { get; set; } = 100;
    public double Volume { get; set; } = 50;

    public string ElapsedEpisodeTimePropName => nameof(ElapsedEpisodeTime);
    public string VolumePropName => nameof(Volume);
}