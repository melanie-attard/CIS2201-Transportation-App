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
		if (schedules != null) { routeSchedule.ItemsSource = schedules; }

		if(App.AppRepo.manager.Paid == true)
		{
			paymentStats.Text = "PAID";
		}
	}

    private async void EnterBusClicked(object sender, EventArgs e)
    {
		// verify that user has paid
		if(App.AppRepo.manager.Paid == true)
		{
            // add route instance to summary list
			Route currentRoute = await App.AppRepo.GetRouteById(RouteId); 
			if (currentRoute != null) { App.AppRepo.manager.EnterBus(currentRoute); }

            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "You are now on the bus.";
        }
		else
		{
			ErrorMsg.IsVisible = true;
			ErrorMsg.Text = "You must pay before entering the bus!";
		}

    }

    private async void StopClicked(object sender, EventArgs e)
    {
		// set stop variable to true
		App.AppRepo.Stop = true;

		// reset paid boolean to false
		App.AppRepo.manager.Paid = false;

        // retrieved from https://lalorosas.com/blog/shell-routing
        await Shell.Current.Navigation.PopAsync();
    }
}