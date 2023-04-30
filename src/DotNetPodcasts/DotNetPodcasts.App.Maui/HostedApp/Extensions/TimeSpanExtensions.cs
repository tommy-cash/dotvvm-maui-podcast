namespace DotNetPodcasts.App.Maui.HostedApp.Extensions;

public static class TimeSpanExtensions
{
    public static DateTime ToDateTime(this TimeSpan value)
    {
        return new DateTime(2000,
            1,
            1,
            value.Hours,
            value.Minutes,
            value.Seconds);
    }
}