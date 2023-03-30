using DotNetPodcasts.App.Web.Components.EpisodePlayer;
using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.App.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetPodcasts.App.Web.Pages.SubscribedPodcasts;

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