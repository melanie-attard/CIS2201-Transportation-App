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

	void UpdateUI(int routeId)
	{
		Title = "Route " + routeId;
	}

    private void EnterBusClicked(object sender, EventArgs e)
    {
		// add route instance to summary list
    }

    private async void StopClicked(object sender, EventArgs e)
    {
        // set stop variable to true

        // retrieved from https://lalorosas.com/blog/shell-routing
        await Shell.Current.Navigation.PopAsync();
    }
}