using System.Globalization;
using CommunityToolkit.Maui.Core.Primitives;
using DotNetPodcasts.App.Maui.HostedApp.Components.EpisodePlayer;
using DotNetPodcasts.App.Maui.HostedApp.Extensions;
using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotNetPodcasts.App.Maui.HostedApp.Routing;
using DotVVM.Framework.Hosting.Maui.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetPodcasts.App.Maui;

public partial class MainPage : ContentPage
{
    public bool IsPageLoaded { get; set; }
    public string RouteName { get; set; }

    public MainPage()
	{
		InitializeComponent();

        BindingContext = new MainPageViewModel() { RouteName = Routes.Public.Default };

        mediaElement.MediaOpened += OnMediaOpened;
        mediaElement.PositionChanged += MediaElement_PositionChanged;
        mediaElement.StateChanged += MediaElement_StateChanged;
    }

    private async void MediaElement_StateChanged(object sender, MediaStateChangedEventArgs e)
    {
        bool isPlaying = mediaElement.CurrentState == MediaElementState.Playing;

        await Dispatcher.DispatchAsync(() =>
        {
            DotvvmPage.PatchViewModel(new
            {
                EpisodePlayerViewModel = new
                {
                    EpisodePlayer = new
                    {
                        IsPlaying = isPlaying
                    }
                }
            });
        });
    }

    private async void MediaElement_PositionChanged(object sender, MediaPositionChangedEventArgs e)
    {
        var elapsedEpisodeTime = e.Position.ToDateTime();
        var totalEpisodeTime = mediaElement.Duration.ToDateTime();
        var isPlaying = mediaElement.CurrentState == MediaElementState.Playing;

        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    IsPlaying = isPlaying,
                    ElapsedEpisodeTime = e.Position.TotalSeconds,
                    ElapsedEpisodeDateTime = elapsedEpisodeTime,
                    TotalEpisodeTime = mediaElement.Duration.TotalSeconds,
                    TotalEpisodeDateTime = totalEpisodeTime
                }
            }
        });
    }

    private async void OnMediaOpened(object sender, EventArgs e)
    {
        await UpdateTotalDuration();
    }
    
    private async Task UpdateTotalDuration()
    {
        var totalEpisodeTime = mediaElement.Duration.ToDateTime();

        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    IsPlaying = true,
                    TotalEpisodeTime = mediaElement.Duration.TotalSeconds,
                    TotalEpisodeDateTime = totalEpisodeTime
                }
            }
        });
    }

    private async Task UpdatePlaying(bool isPlaying)
    {
        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    IsPlaying = isPlaying
                }
            }
        });
    }

    public async void Play()
    {
        var dotvvmStateDynamic = await DotvvmPage.GetViewModelSnapshot();
        var episodeModel = await GetEpisodePlayerFromDotvvmState(dotvvmStateDynamic);
        var url = mediaElement.Source?.ToString()?.Replace("Uri: ", "");

        if (url != episodeModel.EpisodeMediaUrl)
        {
            // set source if changed
            mediaElement.Source = episodeModel.EpisodeMediaUrl;
        }

        if (mediaElement.CurrentState == MediaElementState.Stopped ||
            mediaElement.CurrentState == MediaElementState.Paused || 
            mediaElement.CurrentState == MediaElementState.None)
        {
            if (episodeModel.EpisodeMediaUrl == null)
            {
                return;
            }

            mediaElement.Play();
            await UpdateTotalDuration();
        }
    }

    public async void Pause()
    {
        mediaElement.Pause();
        await UpdatePlaying(false);
    }

    public async void Stop()
    {
        mediaElement.Stop();
        await UpdatePlaying(false);
    }

    public async void SetVolume(double volume)
    {
        mediaElement.Volume = volume / 100;

        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    Volume = volume
                }
            }
        });
    }

    public async void SetSpeed(double speed)
    {
        mediaElement.Speed = speed;

        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    PlaybackSpeed = speed
                }
            }
        });
    }

    public async void SetPosition(double position)
    {
        if (position > mediaElement.Duration.TotalSeconds) return;

        position = position < 0 ? 0 : position;

        var newPositionTimeSpan = TimeSpan.FromSeconds(position);

        mediaElement.SeekTo(newPositionTimeSpan);

        var elapsedEpisodeDateTime = newPositionTimeSpan.ToDateTime();

        await DotvvmPage.PatchViewModel(new
        {
            EpisodePlayerViewModel = new
            {
                EpisodePlayer = new
                {
                    ElapsedEpisodeTime = position,
                    ElapsedEpisodeDateTime = elapsedEpisodeDateTime
                }
            }
        });
    }

    private void DotvvmPage_PageNotificationReceived(object sender, PageNotificationEventArgs e)
    {
        var method = GetType().GetMethod(e.MethodName);
        if (method != null)
        {
            method.Invoke(this, e.Arguments);
        }
    }

    private async void GetViewModelStateButton_Clicked(object sender, EventArgs e)
    {
        var viewModelStateSnapshot = await DotvvmPage.GetViewModelSnapshot();
        await DisplayAlert("View Model State", viewModelStateSnapshot, "OK");
    }

    private async void PatchViewModelStateButton_Clicked(object sender, EventArgs e)
    {
        await DotvvmPage.PatchViewModel(new { Title = "Patched page" });
    }

    private async Task<EpisodePlayerModel> GetEpisodePlayerFromDotvvmState(dynamic dotvvmStateDynamic)
    {
        var dotvvmState = JObject.Parse(dotvvmStateDynamic);
        var episodeState = dotvvmState["EpisodePlayerViewModel"];

        if (episodeState != null)
        {
            var episodePlayerState = episodeState["EpisodePlayer"];

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<EpisodePlayerModel>(episodePlayerState.ToString(), jsonSerializerSettings);
        }
        return null;
    }
}

