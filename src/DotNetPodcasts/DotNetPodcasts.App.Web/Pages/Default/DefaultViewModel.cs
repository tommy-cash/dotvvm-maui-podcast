using DotNetPodcasts.App.Web.Components.EpisodePlayer;
using System.Collections.Generic;
using DotNetPodcasts.App.Web.Models;
using System.Threading.Tasks;
using DotNetPodcasts.App.Web.Facades;
using DotNetPodcasts.Persistence;

namespace DotNetPodcasts.App.Web.Pages.Default;

public class DefaultViewModel : MasterPageViewModel
{
    private readonly PodcastFacade podcastFacade;

    public List<PodcastListModel> Podcasts { get; set; } = new();
    
    public DefaultViewModel(EpisodePlayerViewModel podcastPlayerViewModel, PodcastFacade podcastFacade) 
        : base(podcastPlayerViewModel)
    {
        this.podcastFacade = podcastFacade;
    }

    public override Task Load()
    {
        Podcasts = podcastFacade.GetAll();

        return base.Load();
    }

    public void SubscribeToPodcast(int podcastId)
    {
        
    }
}