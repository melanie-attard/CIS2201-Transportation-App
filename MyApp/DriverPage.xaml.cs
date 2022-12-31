using MyApp.Models;

namespace MyApp;

public partial class DriverPage : ContentPage
{
    bool driverFound = false;
    Driver driver;
    Bus bus;
	public DriverPage()
	{
		InitializeComponent();
    }

    private async void driverBtn_Clicked(object sender, EventArgs e)
    {
		int driverId = Convert.ToInt32(driverEntry.Text);
        // load driver from database
        driver = await App.AppRepo.GetDriverById(driverId);

        if(driver != null)
        {
            driverFound= true;
            if(driver.Assigned == true)
            {              
                if(ErrorMsg.IsVisible == true) { ErrorMsg.IsVisible = false; }
                // load assigned bus and update UI
                bus = await App.AppRepo.GetBusByDriver(driverId);
                if(bus != null)
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

                    if (App.AppRepo.Stop == true)
                    {
                        stopSign.Text = "ON";
                    }

                    List<Schedule> schedule = await App.AppRepo.GetScheduleByRoute(bus.RouteId);
                    driverSchedule.ItemsSource = schedule;
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

    private async void endShiftBtn_Clicked(object sender, EventArgs e)
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

            // set driver's assigned bool to false
            driver.Assigned = false;
            await App.AppRepo.UpdateDriverAsync(driver);

            // reset bus's driverId and assigned bool
            bus.Assigned = false;
            bus.DriverId = 0;
            await App.AppRepo.UpdateBusAsync(bus);
        }
    }
}