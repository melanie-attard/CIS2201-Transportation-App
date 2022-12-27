using MyApp.Models;

namespace MyApp;

public partial class DriverPage : ContentPage
{
    Driver driver = new()
    {
        Id = 1,
        Name= "Test",
        Assigned = false
    };

    bool driverFound = false;
	public DriverPage()
	{
		InitializeComponent();
	}

    private void driverBtn_Clicked(object sender, EventArgs e)
    {
		int driverId = Convert.ToInt32(driverEntry.Text);
        // load driver from database
        if(driverId == driver.Id)
        {
            driverFound= true;
            if(driver.Assigned == true)
            {
                // load assigned bus
                if(ErrorMsg.IsVisible == true) { ErrorMsg.IsVisible = false; }
            }
            else
            {
                ErrorMsg.IsVisible = true;
                ErrorMsg.Text = "No route has been assigned. Please consult your manager.";
            }
        }
        else
        {
            // Id does not exist, output error message
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "This driver ID is not registered!";
        }
    }

    private void resetStopBtn_Clicked(object sender, EventArgs e)
    {
        if(stopSign.Text == "ON")
        {
            stopSign.Text = "OFF";
        }

        // if stop variable is true, set to false
    }

    private void endShiftBtn_Clicked(object sender, EventArgs e)
    {
        if(driverFound == true)
        {
            // reset all fields
            Route.Text = "null";
            busNum.Text = "null";
            Capacity.Text = "null";
            DisabilitySupport.Text = "null";
            driverSchedule.ItemsSource = null;
            stopSign.Text = "OFF";
            driverFound = false;
        }
        // set driver's assigned bool to false
        // reset bus's driverId and assigned bool
    }
}