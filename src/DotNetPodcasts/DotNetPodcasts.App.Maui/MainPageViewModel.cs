using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DotNetPodcasts.App.Maui;

public class MainPageViewModel : INotifyPropertyChanged
{
    private string routeName;
    public string RouteName
    {
        get { return routeName; }
        set
        {
            routeName = value;
            OnPropertyChanged();
        }
    }

    private bool isPageLoaded;
    public bool IsPageLoaded
    {
        get { return isPageLoaded; }
        set
        {
            isPageLoaded = value;
            OnPropertyChanged();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName!));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}