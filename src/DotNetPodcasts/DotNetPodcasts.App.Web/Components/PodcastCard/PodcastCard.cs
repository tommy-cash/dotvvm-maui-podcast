using DotNetPodcasts.App.Web.Models;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;

namespace DotNetPodcasts.App.Web.Components.PodcastCard;

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