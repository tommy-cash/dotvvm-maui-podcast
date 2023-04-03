namespace DotNetPodcasts.App.Maui.HostedApp.Models;

public class EpisodePlayerModel : ModelBase
{
    public string EpisodeName { get; set; } = "Episode name long long long long long long long long long long";
    public string PodcastName { get; set; } = "Podcast name";
    public string ElapsedEpisodeTimeDisplayText => TimeSpan.FromSeconds(ElapsedEpisodeTime).ToString(@"hh\:mm\:ss");
    public double ElapsedEpisodeTime { get; set; } = 0;
    public string TotalEpisodeTimeDisplayText => TimeSpan.FromSeconds(TotalEpisodeTime).ToString(@"hh\:mm\:ss");
    public double TotalEpisodeTime { get; set; } = 0;
    public int Volume { get; set; } = 50;
    public double PlaybackSpeed { get; set; } = 1;
    public bool IsPlaying { get; set; }

    public string ElapsedEpisodeTimePropName => nameof(ElapsedEpisodeTime);
    public string VolumePropName => nameof(Volume);
}