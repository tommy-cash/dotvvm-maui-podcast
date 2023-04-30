using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.App.Maui.HostedApp.Pages;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;

public class EpisodePlayerViewModel : ViewModelBase
{
    private readonly EpisodeFacade episodeFacade;
    private readonly PodcastFacade podcastFacade;

    public EpisodePlayerModel EpisodePlayer { get; set; } = new();

    public EpisodePlayerViewModel(EpisodeFacade episodeFacade, PodcastFacade podcastFacade)
    {
        this.episodeFacade = episodeFacade;
        this.podcastFacade = podcastFacade;
    }

    public override Task Init()
    {
        EpisodePlayer.Volume = Preferences.Default.Get(EpisodePlayerModel.VolumePreferenceKey, 50);

        var episodeId = Preferences.Default.Get(EpisodePlayerModel.LastPlayedEpisodePreferenceKey, 0);
        if (episodeId != default)
        {
            UpdateEpisode(episodeId);
        }

        return base.Init();
    }

    public void UpdateEpisode(int episodeId)
    {
        var episode = episodeFacade.GetById(episodeId);
        var podcast = podcastFacade.GetById(episode.PodcastId);

        EpisodePlayer.EpisodeId = episode.Id;
        EpisodePlayer.PodcastName = podcast.Name;
        EpisodePlayer.EpisodeName = episode.Name;
        EpisodePlayer.IsEpisodeSaved = episode.IsSaved;
        EpisodePlayer.EpisodeMediaUrl = episode.MediaUrl;
        EpisodePlayer.PodcastImageUrl = podcast.ImageUrl;

        Preferences.Default.Set(EpisodePlayerModel.LastPlayedEpisodePreferenceKey, episode.Id);
    }

    public void SaveEpisode()
    {
        if (EpisodePlayer.EpisodeId != default)
        {
            EpisodePlayer.IsEpisodeSaved = episodeFacade.ToggleBookmark(EpisodePlayer.EpisodeId);
        }
    }
}