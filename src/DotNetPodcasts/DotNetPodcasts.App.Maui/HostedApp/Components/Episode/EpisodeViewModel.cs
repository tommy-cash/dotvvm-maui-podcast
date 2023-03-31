using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.App.Maui.HostedApp.Pages;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.Episode;

public class EpisodeViewModel : ViewModelBase
{
    private readonly EpisodeFacade episodeFacade;

    public EpisodeViewModel(EpisodeFacade episodeFacade)
    {
        this.episodeFacade = episodeFacade;
    }

    public void ToggleEpisodeBookmark(EpisodeListModel episode)
    {
        episodeFacade.ToggleBookmark(episode.Id);
        episode.IsSaved = !episode.IsSaved;
    }
}