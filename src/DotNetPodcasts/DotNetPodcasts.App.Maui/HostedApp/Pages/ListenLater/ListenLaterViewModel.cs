using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.ListenLater;

public class ListenLaterViewModel : MasterPageViewModel
{
    private readonly EpisodeFacade episodeFacade;

    public List<EpisodeListModel> SavedForLaterEpisodes { get; set; }

    public ListenLaterViewModel(EpisodePlayerViewModel podcastPlayerViewModel, EpisodeFacade episodeFacade)
        : base(podcastPlayerViewModel)
    {
        this.episodeFacade = episodeFacade;
    }
    
    public override Task Load()
    {
        SavedForLaterEpisodes = episodeFacade.GetAllSavedForLater();

        return base.Load();
    }
}