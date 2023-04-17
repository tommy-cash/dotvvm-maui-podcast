using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.App.Maui.HostedApp.Pages;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.Episode;

public class EpisodeViewModel : ViewModelBase
{
    private readonly EpisodeFacade episodeFacade;

    public EpisodePlayerViewModel EpisodePlayerViewModel { get; set; }

    public EpisodeViewModel(EpisodeFacade episodeFacade, EpisodePlayerViewModel episodePlayerViewModel)
    {
        this.episodeFacade = episodeFacade;
        EpisodePlayerViewModel = episodePlayerViewModel;
    }

    public void ToggleEpisodeBookmark(EpisodeListModel episode)
    {
        episodeFacade.ToggleBookmark(episode.Id);
        episode.IsSaved = !episode.IsSaved;
    }

    public void Play(EpisodeListModel episode)
    {
        EpisodePlayerViewModel.UpdateEpisode(episode.Id);
    }
}