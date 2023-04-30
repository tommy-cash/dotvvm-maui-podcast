using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.Persistence;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.Options;

public class OptionsViewModel : MasterPageViewModel
{
    private readonly Seeder seeder;

    public OptionsViewModel(EpisodePlayerViewModel episodePlayerViewModel, Seeder seeder)
        : base(episodePlayerViewModel)
    {
        this.seeder = seeder;
    }

    public void SeedData()
    {
        seeder.SeedPodcasts();
        Preferences.Default.Clear();
    }
}