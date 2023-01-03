using MyApp.Models;

namespace MyApp;

public partial class DriverManagerPage : ContentPage
{
	public DriverManagerPage()
	{
		InitializeComponent();
	}

    private async void assignBtn_Clicked(object sender, EventArgs e)
    {
        int dId = App.AppRepo.CheckID(DriverId.Text);
        if(dId == 0)
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = App.AppRepo.StatusMessage;
            return;
        }

        int rId = App.AppRepo.CheckID(RouteId.Text);
        if(rId == 0)
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = App.AppRepo.StatusMessage;
            return;
        }

        // check whether driver Id and route Id exist
        Driver driver = await App.AppRepo.GetDriverById(dId);
        Bus bus = await App.AppRepo.GetBusByRoute(rId);

        if(driver == null) 
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "Driver Id does not exist!"; 
            return; 
        }

        if(bus == null) 
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "Route Id does not exist!"; 
            return; 
        }

        // check that both are not already assigned
        if(driver.Assigned == true) 
        {
            ErrorMsg.IsVisible = true; 
            ErrorMsg.Text = "The given driver is already assigned!"; 
            return; 
        }

        if(bus.Assigned == true) 
        { 
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "The given route already has a driver!"; 
            return; 
        }

        // assign driver to route
        driver.Assigned = true;
        bus.Assigned = true;
        bus.DriverId = dId;
        await App.AppRepo.UpdateBusAsync(bus);
        await App.AppRepo.UpdateDriverAsync(driver);
        ErrorMsg.IsVisible = true;
        ErrorMsg.Text = "Driver successfully assigned to route " + rId;
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
        await Shell.Current.GoToAsync("editDriver");
    }
}