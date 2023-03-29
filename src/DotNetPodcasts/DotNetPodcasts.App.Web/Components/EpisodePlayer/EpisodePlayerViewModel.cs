using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.App.Web.Pages;

namespace DotNetPodcasts.App.Web.Components.EpisodePlayer;

public class EpisodePlayerViewModel : ViewModelBase
{
    private readonly EpisodeFacade episodeFacade;
    private decimal previousEpisodeVolume = 0;
    
    public EpisodePlayerModel EpisodePlayer { get; set; } = new();
    public string EpisodePlayerPropName => nameof(EpisodePlayer);

    public EpisodePlayerViewModel(EpisodeFacade episodeFacade)
    {
        this.episodeFacade = episodeFacade;
    }

    public void MuteAudio()
    {
        previousEpisodeVolume = EpisodePlayer.Volume;
        EpisodePlayer.Volume = 0;
    }

    public void UnmuteAudio()
    {
        EpisodePlayer.Volume = previousEpisodeVolume;
    }

    public void IncreasePlaybackSpeed()
    {
        if (EpisodePlayer.PlaybackSpeed >= 2)
        {
            return;
        }

        EpisodePlayer.PlaybackSpeed += 0.25m;
    }

    public void DecreasePlaybackSpeed()
    {
        if (EpisodePlayer.PlaybackSpeed == 0.25m)
        {
            return;
        }

        EpisodePlayer.PlaybackSpeed -= 0.25m;
    }

    public void SaveEpisode()
    {
        //episodeFacade.ToggleBookmark();
    }

    public void PlayEpisode()
    {
        EpisodePlayer.IsPlaying = true;
    }

    public void PauseEpisode()
    {
        EpisodePlayer.IsPlaying = false;
    }

    public void SkipSeconds(int seconds)
    {

    }

    public void ReturnSeconds(int seconds)
    {

    }
}