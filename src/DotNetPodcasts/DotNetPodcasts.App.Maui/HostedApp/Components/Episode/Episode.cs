using DotNetPodcasts.App.Maui.HostedApp.Models;
using DotVVM.Framework.Binding;

namespace DotNetPodcasts.App.Maui.HostedApp.Components.Episode;

public class Episode : DotvvmMarkupControlBase
{
    public EpisodeListModel EpisodeModel
    {
        get { return (EpisodeListModel)GetValue(EpisodeModelProperty); }
        set { SetValue(EpisodeModelProperty, value); }
    }
    public static readonly DotvvmProperty EpisodeModelProperty
        = DotvvmProperty.Register<EpisodeListModel, Episode>(c => c.EpisodeModel, null);
}