using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages;

public class MasterPageViewModel : ViewModelBase
{
    public EpisodePlayerViewModel EpisodePlayerViewModel { get; set; }

    public MasterPageViewModel(EpisodePlayerViewModel podcastPlayerViewModel)
    {
        EpisodePlayerViewModel = podcastPlayerViewModel;
    }
}