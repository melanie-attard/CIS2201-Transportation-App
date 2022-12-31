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

    private async void UpdateUI(string stopName)
    {
        Title = stopName;
        BusStop stop = await App.AppRepo.GetStopByName(stopName);
        if (stop != null)
        {
            stopId.Text = stop.Id.ToString();
            location.Text = stop.Longitude + "  " + stop.Latitude;
        }

        List<Schedule> schedules = await App.AppRepo.GetScheduleByStop(stop.Id);
        if (schedules != null) { timetable.ItemsSource = schedules; }
    }

    // To do:
    // List<Schedule> ordered by time1, for closest list
}