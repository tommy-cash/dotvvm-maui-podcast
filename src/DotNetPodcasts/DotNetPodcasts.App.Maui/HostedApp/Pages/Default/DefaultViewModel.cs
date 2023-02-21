namespace DotNetPodcasts.App.Maui.HostedApp.Pages.Default;

public class DefaultViewModel : MasterPageViewModel
{

    public string Title { get; set;}

    public DefaultViewModel()
    {
        Title = "Hello from DotVVM!";
    }

}