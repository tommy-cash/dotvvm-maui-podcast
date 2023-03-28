using DotNetPodcasts.App.Web.Components.PodcastPlayer;

namespace DotNetPodcasts.App.Web.Pages.PodcastDetail;

public class PodcastDetailViewModel : MasterPageViewModel
{
    public PodcastDetailViewModel(PodcastPlayerViewModel podcastPlayerViewModel) 
        : base(podcastPlayerViewModel)
    {
    }
}