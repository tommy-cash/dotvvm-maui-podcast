using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotVVM.Framework.Binding;
using Command = DotVVM.Framework.Binding.Expressions.Command;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.PodcastCard;

public class PodcastCard : DotvvmMarkupControlBase
{
    public PodcastListModel Podcast
    {
        get { return (PodcastListModel)GetValue(PodcastProperty); }
        set { SetValue(PodcastProperty, value); }
    }
    public static readonly DotvvmProperty PodcastProperty
        = DotvvmProperty.Register<PodcastListModel, PodcastCard>(c => c.Podcast, null);

    public Command IconClicked
    {
        get { return (Command)GetValue(IconClickedProperty); }
        set { SetValue(IconClickedProperty, value); }
    }
    public static readonly DotvvmProperty IconClickedProperty
        = DotvvmProperty.Register<Command, PodcastCard>(c => c.IconClicked, null);
}