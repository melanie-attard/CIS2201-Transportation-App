using MyApp.Models;

namespace MyApp;

[QueryProperty(nameof(RouteId), "routeId")]
public partial class RouteDetailsPage : ContentPage
{
	int routeId;
	public int RouteId
	{
		get => routeId;
		set
		{
			routeId = value;

			UpdateUI(routeId);
		}
	}

	public RouteDetailsPage()
	{
		InitializeComponent();
	}

	private async void UpdateUI(int routeId)
	{
		Title = "Route " + routeId;
		List<Schedule> schedules = await App.AppRepo.GetScheduleByRoute(routeId);
		routeSchedule.ItemsSource = schedules;
	}

    private void EnterBusClicked(object sender, EventArgs e)
    {
		// verify that user is set to paid
		// add route instance to summary list
    }

    private async void StopClicked(object sender, EventArgs e)
    {
		// set stop variable to true
		App.AppRepo.Stop = true;

		// reset paid boolean to false

        // retrieved from https://lalorosas.com/blog/shell-routing
        await Shell.Current.Navigation.PopAsync();
    }
}