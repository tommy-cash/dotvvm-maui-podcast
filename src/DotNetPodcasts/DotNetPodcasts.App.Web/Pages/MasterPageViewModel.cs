using DotNetPodcasts.App.Web.Components.PodcastPlayer;

namespace DotNetPodcasts.App.Web.Pages;

public class MasterPageViewModel : ViewModelBase
{
    public PodcastPlayerViewModel PodcastPlayerViewModel { get; set; }

    public MasterPageViewModel(PodcastPlayerViewModel podcastPlayerViewModel)
    {
        PodcastPlayerViewModel = podcastPlayerViewModel;
    }
}