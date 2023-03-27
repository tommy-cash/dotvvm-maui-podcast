using DotNetPodcasts.App.Web.Models;

namespace DotNetPodcasts.App.Web.Pages;

public class MasterPageViewModel : ViewModelBase
{
    public PodcastPlayerModel PodcastPlayer { get; set; } = new ();

    public MasterPageViewModel()
    {
        
    }
}