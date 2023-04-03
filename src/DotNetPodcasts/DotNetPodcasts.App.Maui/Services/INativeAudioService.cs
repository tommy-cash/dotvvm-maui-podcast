namespace DotNetPodcasts.App.Maui.Services;

public interface INativeAudioService
{
    Task SetupAsync(string audioUrl);

    Task PlayAsync(double position = 0);

    Task PauseAsync();

    Task SetMuted(bool value);

    Task SetVolume(int value);

    Task SetCurrentTime(double value);

    ValueTask DisposeAsync();

    bool IsPlaying { get; }

    double CurrentPosition { get; }
    double TotalDuration { get; }

    event EventHandler<bool> IsPlayingChanged;
}