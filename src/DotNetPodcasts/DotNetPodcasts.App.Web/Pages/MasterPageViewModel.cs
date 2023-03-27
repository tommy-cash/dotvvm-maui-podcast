namespace DotNetPodcasts.App.Web.Pages
{
    public class MasterPageViewModel : ViewModelBase
    {
        public double PlayTime { get; set; } = 20;
        public double Volume  => 70;
        public string EpisodeName => "Episode name long long long long long long long long long long";
        public string PodcastName => "Podcast name";
    }
}