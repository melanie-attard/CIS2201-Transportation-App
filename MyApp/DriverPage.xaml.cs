using MyApp.Models;

namespace MyApp;

public partial class DriverPage : ContentPage
{
    bool driverFound = false;
	public DriverPage()
	{
		InitializeComponent();

        bool stop = App.AppRepo.Stop;
        if(stop == true)
        {
            stopSign.Text = "ON";
        }
	}

    private async void driverBtn_Clicked(object sender, EventArgs e)
    {
		int driverId = Convert.ToInt32(driverEntry.Text);
        // load driver from database
        Driver driver = await App.AppRepo.GetDriverById(driverId);

        if(driver is not null)
        {
            driverFound= true;
            if(driver.Assigned == true)
            {              
                if(ErrorMsg.IsVisible == true) { ErrorMsg.IsVisible = false; }
                // load assigned bus and update UI
                Bus bus = await App.AppRepo.GetBusByDriver(driverId);
                if(bus is not null)
                {
                    Route.Text = bus.RouteId.ToString();
                    busNum.Text = bus.BusId.ToString();
                    Capacity.Text = bus.Capacity.ToString();
                    if(bus.DisabilitySupport == true) 
                    {
                        DisabilitySupport.Text = "Yes";
                    }
                    else
                    {
                        DisabilitySupport.Text = "No";
                    }
                }
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
            App.AppRepo.Stop = false;
        }
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