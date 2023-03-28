using DotNetPodcasts.App.Web.Components.EpisodePlayer;

namespace DotNetPodcasts.App.Web.Pages.Default;

public class DefaultViewModel : MasterPageViewModel
{
    public DefaultViewModel(EpisodePlayerViewModel podcastPlayerViewModel) 
        : base(podcastPlayerViewModel)
    {
    }

    public void SubscribeToPodcast()
    {

    }
}