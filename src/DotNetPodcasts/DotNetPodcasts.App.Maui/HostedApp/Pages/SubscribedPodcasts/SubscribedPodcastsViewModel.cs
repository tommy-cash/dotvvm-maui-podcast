using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.SubscribedPodcasts;

public class SubscribedPodcastsViewModel : MasterPageViewModel
{
    private readonly PodcastFacade podcastFacade;

    public List<PodcastListModel> SubscribedPodcasts { get; set; } = new();
    
    public SubscribedPodcastsViewModel(EpisodePlayerViewModel podcastPlayerViewModel, PodcastFacade podcastFacade)
        : base(podcastPlayerViewModel)
    {
        this.podcastFacade = podcastFacade;
    }

    public override Task Load()
    {
        SubscribedPodcasts = podcastFacade.GetAllSubscribed();
        return base.Load();
    }

    public void ToggleSubscribe(PodcastListModel podcast)
    {
        podcastFacade.ToggleSubscribe(podcast.Id);
        podcast.IsSubscribed = !podcast.IsSubscribed;
    }
}