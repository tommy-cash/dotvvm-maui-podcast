using System.Collections.Generic;
using DotNetPodcasts.App.Web.Components.EpisodePlayer;
using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.App.Web.Models;
using System.Threading.Tasks;

namespace DotNetPodcasts.App.Web.Pages.ListenLater;

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