using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;

namespace DotNetPodcasts.App.Web.Components.PodcastCard;

public class PodcastCard : DotvvmMarkupControlBase
{
    public Command IconClicked
    {
        get { return (Command)GetValue(IconClickedProperty); }
        set { SetValue(IconClickedProperty, value); }
    }
    public static readonly DotvvmProperty IconClickedProperty
        = DotvvmProperty.Register<Command, PodcastCard>(c => c.IconClicked, null);
}