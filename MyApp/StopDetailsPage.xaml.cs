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

    void UpdateUI(string stopName)
    {
        Title = stopName;
    }

    // To do:
    // return stop instance with given name to output id and location
    // List<Schedule> containing routes passing from this stop
    // List<Schedule> ordered by time1, for closest list
}