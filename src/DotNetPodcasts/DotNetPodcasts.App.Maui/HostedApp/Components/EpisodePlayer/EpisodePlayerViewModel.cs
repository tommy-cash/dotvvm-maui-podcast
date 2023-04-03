using System.Timers;
using DotNetPodcasts.App.Maui.HostedApp.Facades;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.App.Maui.HostedApp.Pages;
using DotNetPodcasts.App.Maui.Services;
using DotVVM.Framework.Controls;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;

public class EpisodePlayerViewModel : ViewModelBase
{
    private readonly EpisodeFacade episodeFacade;
    private readonly INativeAudioService nativeAudioService;
    private int previousVolume = 0;

    public EpisodePlayerModel EpisodePlayer { get; set; } = new();
    public string EpisodePlayerPropName => nameof(EpisodePlayer);

    public EpisodePlayerViewModel(EpisodeFacade episodeFacade, INativeAudioService nativeAudioService)
    {
        this.episodeFacade = episodeFacade;
        this.nativeAudioService = nativeAudioService;
    }

    public async Task MuteAudio()
    {
        previousVolume = EpisodePlayer.Volume;
        EpisodePlayer.Volume = 0;

        await nativeAudioService.SetMuted(true);
    }

    public async Task UnmuteAudio()
    {
        EpisodePlayer.Volume = previousVolume;

        await nativeAudioService.SetMuted(false);
    }

    public async Task SetVolume(int volume)
    {
        previousVolume = EpisodePlayer.Volume;
        await nativeAudioService.SetVolume(volume);
    }

    public void IncreasePlaybackSpeed()
    {
        if (EpisodePlayer.PlaybackSpeed >= 2)
        {
            return;
        }

        EpisodePlayer.PlaybackSpeed += 0.25;
    }

    public void DecreasePlaybackSpeed()
    {
        if (EpisodePlayer.PlaybackSpeed.Equals(0.25))
        {
            return;
        }

        EpisodePlayer.PlaybackSpeed -= 0.25;
    }

    public void SaveEpisode()
    {
        //episodeFacade.ToggleBookmark();
    }

    public async Task PlayEpisode()
    {
        //var audioUrl = "https://free-stock-music.com/music/enlia-ethereal-theme.mp3";
        var audioUrl = "https://filesamples.com/samples/audio/mp3/sample2.mp3";

        await nativeAudioService.SetupAsync(audioUrl);
        
        await nativeAudioService.PlayAsync(EpisodePlayer.ElapsedEpisodeTime);

        EpisodePlayer.IsPlaying = true;
    }

    public void UpdateElapsedTime()
    {
        if (EpisodePlayer.IsPlaying)
        {
            EpisodePlayer.ElapsedEpisodeTime = (int)nativeAudioService.CurrentPosition;
            EpisodePlayer.TotalEpisodeTime = nativeAudioService.TotalDuration;
        }
    }

    public async Task PauseEpisode()
    {
        await nativeAudioService.PauseAsync();
        EpisodePlayer.IsPlaying = false;
    }

    public async Task SkipSeconds(int seconds)
    {
        await nativeAudioService.SetCurrentTime(EpisodePlayer.ElapsedEpisodeTime + seconds);
    }

    public async Task ReturnSeconds(int seconds)
    {
        await nativeAudioService.SetCurrentTime(EpisodePlayer.ElapsedEpisodeTime - seconds);
    }
}