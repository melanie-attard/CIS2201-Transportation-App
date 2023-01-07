using MyApp.Models;

namespace MyApp;

public partial class DeleteDriverPage : ContentPage
{
	public DeleteDriverPage()
	{
		InitializeComponent();
	}

    private async void deleteBtn_Clicked(object sender, EventArgs e)
    {
        int dId = App.AppRepo.CheckID(DriverId.Text);
        if (dId == 0)
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = App.AppRepo.StatusMessage;
            return;
        }

        // check that the driver exists
        Driver driver = await App.AppRepo.GetDriverById(dId);
        if (driver == null)
        {
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "Driver Id does not exist!";
            return;
        }

        // if driver is assigned, unassign him before deleting
        if(driver.Assigned == true)
        {
            Bus bus = await App.AppRepo.GetBusByDriver(dId);
            if (bus != null)
            {
                bus.Assigned = false;
                await App.AppRepo.UpdateBusAsync(bus);
            }
        }

        // delete driver from database
        await App.AppRepo.DeleteDriverAsync(driver);
        ErrorMsg.IsVisible = true;
        ErrorMsg.Text = "Driver deleted successfully!";
    }
}