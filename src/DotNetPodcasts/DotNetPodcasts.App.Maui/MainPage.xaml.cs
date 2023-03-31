using DotNetPodcasts.App.Maui.HostedApp.Routing;
using DotVVM.Framework.Hosting.Maui.Controls;
using Newtonsoft.Json;

namespace DotNetPodcasts.App.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        BindingContext = new MainPageViewModel() { RouteName = Routes.Public.Default };
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}
    
    private async void DotvvmPage_PageNotificationReceived(object sender, PageNotificationEventArgs e)
    {
        await DisplayAlert("PageNotification", e.MethodName + "(" + string.Join(", ", e.Arguments.Select(JsonConvert.SerializeObject)) + ")", "OK");
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
}

