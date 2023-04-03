using Windows.Media.Core;
using Windows.Media.Playback;
using DotNetPodcasts.App.Maui.Services;

namespace DotNetPodcasts.App.Maui.Platforms.Windows;

public class NativeAudioService : INativeAudioService
{
    private string url;
    private MediaPlayer mediaPlayer;

    public bool IsPlaying => mediaPlayer != null && mediaPlayer.CurrentState == MediaPlayerState.Playing;

    public double CurrentPosition => mediaPlayer?.Position.TotalSeconds ?? 0;
    public double TotalDuration  => mediaPlayer?.NaturalDuration.TotalSeconds ?? 0;

    public event EventHandler<bool> IsPlayingChanged;

    public async Task SetupAsync(string audioUrl)
    {
        url = audioUrl;

        if (mediaPlayer == null)
        {
            mediaPlayer = new MediaPlayer
            {
                Source = MediaSource.CreateFromUri(new Uri(url)),
                AudioCategory = MediaPlayerAudioCategory.Media
            };
        }

        if (mediaPlayer != null)
        {
            await PauseAsync();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(url));
        }
    }

    public Task PauseAsync()
    {
        mediaPlayer?.Pause();
        return Task.CompletedTask;
    }

    public Task PlayAsync(double position = 0)
    {
        if (mediaPlayer != null)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(position);
            mediaPlayer.Play();
        }

        return Task.CompletedTask;
    }

    public Task SetCurrentTime(double value)
    {
        if (mediaPlayer != null)
        {
            var time = value > TotalDuration ? TotalDuration : value;
            time = value < 0 ? 0 : time;

            mediaPlayer.Position = TimeSpan.FromSeconds(time);
        }

        return Task.CompletedTask;
    }

    public Task SetMuted(bool value)
    {
        if (mediaPlayer != null)
        {
            mediaPlayer.IsMuted = value;
        }

        return Task.CompletedTask;
    }

    public Task SetVolume(int value)
    {
        if (mediaPlayer != null)
        {
            mediaPlayer.Volume = (double)value / 100;
        }

        return Task.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        mediaPlayer?.Dispose();
        return ValueTask.CompletedTask;
    }
}
