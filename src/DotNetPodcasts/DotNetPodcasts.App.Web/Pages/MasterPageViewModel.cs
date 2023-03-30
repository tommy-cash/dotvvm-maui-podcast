using DotNetPodcasts.App.Web.Components.EpisodePlayer;

namespace DotNetPodcasts.App.Web.Pages;

public class MasterPageViewModel : ViewModelBase
{
    public EpisodePlayerViewModel EpisodePlayerViewModel { get; set; }

    public MasterPageViewModel(EpisodePlayerViewModel podcastPlayerViewModel)
    {
        EpisodePlayerViewModel = podcastPlayerViewModel;
    }
}