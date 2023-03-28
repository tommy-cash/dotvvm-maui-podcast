using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.App.Web.Pages;

namespace DotNetPodcasts.App.Web.Components.PodcastPlayer;

public class PodcastPlayerViewModel : ViewModelBase
{
    private decimal previousEpisodeVolume = 0;
    
    public PodcastPlayerModel PodcastPlayer { get; set; } = new();
    public string PodcastPlayerPropName => nameof(PodcastPlayer);

    public void MuteAudio()
    {
        previousEpisodeVolume = PodcastPlayer.Volume;
        PodcastPlayer.Volume = 0;
    }

    public void UnmuteAudio()
    {
        PodcastPlayer.Volume = previousEpisodeVolume;
    }

    public void IncreasePlaybackSpeed()
    {
        if (PodcastPlayer.PlaybackSpeed >= 2)
        {
            return;
        }

        PodcastPlayer.PlaybackSpeed += 0.25m;
    }

    public void DecreasePlaybackSpeed()
    {
        if (PodcastPlayer.PlaybackSpeed == 0.25m)
        {
            return;
        }

        PodcastPlayer.PlaybackSpeed -= 0.25m;
    }

    public void SaveEpisode()
    {

    }

    public void PlayEpisode()
    {
        PodcastPlayer.IsPlaying = true;
    }

    public void PauseEpisode()
    {
        PodcastPlayer.IsPlaying = false;
    }

    public void SkipSeconds(int seconds)
    {

    }

    public void ReturnSeconds(int seconds)
    {

    }
}