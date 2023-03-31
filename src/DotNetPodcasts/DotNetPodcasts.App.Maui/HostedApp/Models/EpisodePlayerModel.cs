namespace DotNetPodcasts.App.Maui.HostedApp.Models;

public class EpisodePlayerModel : ModelBase
{
    public string EpisodeName { get; set; } = "Episode name long long long long long long long long long long";
    public string PodcastName { get; set; } = "Podcast name";
    public decimal ElapsedEpisodeTime { get; set; } = 20;
    public decimal TotalEpisodeTime { get; set; } = 100;
    public decimal Volume { get; set; } = 50;
    public decimal PlaybackSpeed { get; set; } = 1;
    public bool IsPlaying { get; set; }

    public string ElapsedEpisodeTimePropName => nameof(ElapsedEpisodeTime);
    public string VolumePropName => nameof(Volume);
}