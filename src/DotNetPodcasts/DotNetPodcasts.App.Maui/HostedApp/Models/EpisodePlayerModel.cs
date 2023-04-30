namespace DotNetPodcasts.App.Maui.HostedApp.Models;

public class EpisodePlayerModel
{
    public static string LastPlayedEpisodePreferenceKey = "LastPlayedEpisodeId";
    public static string VolumePreferenceKey = "Volume";

    public int EpisodeId { get; set; } = 0;
    public string EpisodeMediaUrl { get; set; }
    public string PodcastImageUrl { get; set; }
    public bool IsEpisodeSaved { get; set; }
    public string EpisodeName { get; set; }
    public string PodcastName { get; set; }
    public DateTime ElapsedEpisodeDateTime { get; set; } = new (2000, 1, 1, 0, 0, 0);
    public double ElapsedEpisodeTime { get; set; }

    public DateTime TotalEpisodeDateTime { get; set; } = new (2000, 1, 1, 0, 0, 0);
    public double TotalEpisodeTime { get; set; }

    public int PreviousVolume { get; set; }
    public int Volume { get; set; } = 50;
    public double PlaybackSpeed { get; set; } = 1;
    public bool IsPlaying { get; set; }
}