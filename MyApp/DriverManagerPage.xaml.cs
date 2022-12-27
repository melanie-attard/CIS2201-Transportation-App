namespace MyApp;

public partial class DriverManagerPage : ContentPage
{
	public DriverManagerPage()
	{
		InitializeComponent();
	}

    private void assignBtn_Clicked(object sender, EventArgs e)
    {
        // check whether driver Id and route Id exist
    }

    private async void viewDriversBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("viewDrivers");
    }

    private async void newDriverBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("newDriver");
    }

    private async void editDriverBtn_Clicked(object sender, EventArgs e)
    {

    }
}