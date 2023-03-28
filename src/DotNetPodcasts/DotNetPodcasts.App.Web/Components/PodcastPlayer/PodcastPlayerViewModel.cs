using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.App.Web.Pages;

namespace DotNetPodcasts.App.Web.Components.PodcastPlayer;

public class PodcastPlayerViewModel : ViewModelBase
{
    private double previousEpisodeVolume = 0;

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
}