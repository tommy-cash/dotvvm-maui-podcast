namespace DotNetPodcasts.App.Maui.HostedApp.Routing;

public static class Routes
{
    public static class Public
    {
        public static string Default = $"{nameof(Public)}_{nameof(Default)}";
        public static string PodcastDetail = $"{nameof(Public)}_{nameof(PodcastDetail)}";
        public static string SubscribedPodcasts = $"{nameof(Public)}_{nameof(SubscribedPodcasts)}";
        public static string ListenLater = $"{nameof(Public)}_{nameof(ListenLater)}";
        public static string Options = $"{nameof(Public)}_{nameof(Options)}";
    }
    public static class Error
    {
        public static string Error500 = $"{nameof(Error)}_{nameof(Error500)}";
        public static string Error404 = $"{nameof(Error)}_{nameof(Error404)}";
        public static string Error403 = $"{nameof(Error)}_{nameof(Error403)}";
    }
}