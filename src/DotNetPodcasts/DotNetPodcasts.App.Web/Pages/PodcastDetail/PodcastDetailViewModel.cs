using DotNetPodcasts.App.Web.Components.EpisodePlayer;
using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.App.Web.Models;
using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace DotNetPodcasts.App.Web.Pages.PodcastDetail;

public class PodcastDetailViewModel : MasterPageViewModel
{
    private readonly PodcastFacade podcastFacade;

    [FromRoute("Id")]
    public int PodcastId { get; set; }

    public PodcastDetailModel PodcastDetail { get; set; }

    public PodcastDetailViewModel(EpisodePlayerViewModel podcastPlayerViewModel, PodcastFacade podcastFacade) 
        : base(podcastPlayerViewModel)
    {
        this.podcastFacade = podcastFacade;
    }

    public override Task Load()
    {
        PodcastDetail = podcastFacade.GetById(PodcastId);

        return base.Load();
    }

    public void ToggleSubscribe(PodcastDetailModel podcast)
    {
        podcastFacade.ToggleSubscribe(podcast.Id);
        podcast.IsSubscribed = !podcast.IsSubscribed;
    }
}