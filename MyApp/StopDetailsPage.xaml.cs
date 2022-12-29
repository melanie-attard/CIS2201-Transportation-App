using MyApp.Models;

namespace MyApp;

[QueryProperty(nameof(StopName), "stopName")]
public partial class StopDetailsPage : ContentPage
{
    string stopName;
    public string StopName
    {
        get => stopName;
        set
        {
            stopName = value;

            UpdateUI(stopName);
        }
    }
    public StopDetailsPage()
	{
		InitializeComponent();
	}

    async void UpdateUI(string stopName)
    {
        Title = stopName;
        BusStop stop = await App.AppRepo.GetStopByName(stopName);
        if (stop != null)
        {
            stopId.Text = stop.Id.ToString();
            location.Text = stop.Longitude + "  " + stop.Latitude;
        }
    }

    // To do:
    // List<Schedule> containing routes passing from this stop
    // List<Schedule> ordered by time1, for closest list
}