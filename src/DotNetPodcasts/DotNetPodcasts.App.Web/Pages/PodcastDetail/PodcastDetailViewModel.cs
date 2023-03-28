using DotNetPodcasts.App.Web.Components.EpisodePlayer;

namespace DotNetPodcasts.App.Web.Pages.PodcastDetail;

public class PodcastDetailViewModel : MasterPageViewModel
{
    public PodcastDetailViewModel(EpisodePlayerViewModel podcastPlayerViewModel) 
        : base(podcastPlayerViewModel)
    {
    }
}