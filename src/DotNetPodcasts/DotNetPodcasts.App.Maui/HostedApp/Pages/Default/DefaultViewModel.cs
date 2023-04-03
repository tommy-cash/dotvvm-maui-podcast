using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.Default;

public class DefaultViewModel : MasterPageViewModel
{
    private readonly PodcastFacade podcastFacade;

    public List<PodcastListModel> Podcasts { get; set; } = new();

    public DefaultViewModel(EpisodePlayerViewModel episodePlayerViewModel, PodcastFacade podcastFacade) 
        : base(episodePlayerViewModel)
    {
        this.podcastFacade = podcastFacade;
    }

    public override Task Load()
    {
        Podcasts = podcastFacade.GetAll();

        return base.Load();
    }

    public void ToggleSubscribe(PodcastListModel podcast)
    {
        podcastFacade.ToggleSubscribe(podcast.Id);
        podcast.IsSubscribed = !podcast.IsSubscribed;
    }
}