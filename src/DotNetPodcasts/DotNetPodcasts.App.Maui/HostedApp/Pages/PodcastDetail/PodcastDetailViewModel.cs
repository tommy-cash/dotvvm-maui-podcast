using DotNetPodcasts.App.Maui.HostedApp.Components.Episode;
using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotVVM.Framework.ViewModel;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.PodcastDetail;

public class PodcastDetailViewModel : MasterPageViewModel
{
    private readonly PodcastFacade podcastFacade;

    [FromRoute("Id")]
    public int PodcastId { get; set; }

    public PodcastDetailModel PodcastDetail { get; set; }
    public EpisodeViewModel EpisodeViewModel { get; set; }

    public PodcastDetailViewModel(EpisodePlayerViewModel podcastPlayerViewModel, EpisodeViewModel episodeViewModel, PodcastFacade podcastFacade) 
        : base(podcastPlayerViewModel)
    {
        this.podcastFacade = podcastFacade;

        EpisodeViewModel = episodeViewModel;
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