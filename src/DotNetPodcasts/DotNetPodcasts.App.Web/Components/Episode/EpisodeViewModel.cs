using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.App.Web.Models;
using DotNetPodcasts.App.Web.Pages;

namespace DotNetPodcasts.App.Web.Components.Episode;

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