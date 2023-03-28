using DotNetPodcasts.App.Web.Components.PodcastPlayer;

namespace DotNetPodcasts.App.Web.Pages.Default;

public class DefaultViewModel : MasterPageViewModel
{
    public DefaultViewModel(PodcastPlayerViewModel podcastPlayerViewModel) 
        : base(podcastPlayerViewModel)
    {
    }
}