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
}