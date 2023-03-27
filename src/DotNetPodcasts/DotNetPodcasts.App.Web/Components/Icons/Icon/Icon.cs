using DotVVM.Framework.Binding;

namespace DotNetPodcasts.App.Web.Components.Icons.Icon;

public class Icon : DotvvmMarkupControlBase
{
    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }
    public static readonly DotvvmProperty NameProperty
        = DotvvmProperty.Register<string, Icon>(c => c.Name, null);
}