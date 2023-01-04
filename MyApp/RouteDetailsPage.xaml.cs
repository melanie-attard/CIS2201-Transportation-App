using MyApp.Models;

namespace MyApp;

[QueryProperty(nameof(RouteId), "routeId")]
public partial class RouteDetailsPage : ContentPage
{
	int routeId;
	bool enteredBus = false;
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
        List<BusStop> stops = await App.AppRepo.GetAllStops();
        var combined = schedules.Join(stops, s1 => s1.StopId, s2 => s2.Id, (schedules, stops) => new
        {
            stops.Name,
            schedules.Time1,
            schedules.Time2,
            schedules.Time3,
            schedules.Time4,
            schedules.Time5,
            schedules.Time6
        }).ToList();
		routeSchedule.ItemsSource = combined;

        if (App.AppRepo.Manager.Paid == true)
		{
			paymentStats.Text = "PAID";
		}
	}

    private async void EnterBusClicked(object sender, EventArgs e)
    {
		// verify that user has paid
		if(App.AppRepo.Manager.Paid == true)
		{
            // add route instance to summary list
			Route currentRoute = await App.AppRepo.GetRouteById(RouteId); 
			if (currentRoute != null) { App.AppRepo.Manager.EnterBus(currentRoute); }

            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "You are now on the bus.";
			enteredBus = true;
        }
		else
		{
			ErrorMsg.IsVisible = true;
			ErrorMsg.Text = "You must pay before entering the bus!";
		}

    }

    private async void StopClicked(object sender, EventArgs e)
    {
		if(enteredBus == true)
		{
			enteredBus = false;
            // set stop variable to true
            App.AppRepo.Stop = true;

            // reset paid boolean to false
            App.AppRepo.Manager.Paid = false;

            // retrieved from https://lalorosas.com/blog/shell-routing
            await Shell.Current.Navigation.PopAsync();
		}
		else
		{
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "You must be in a bus to press Stop!";
        }
		
    }
}