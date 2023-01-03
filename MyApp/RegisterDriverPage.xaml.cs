using MyApp.Models;

namespace MyApp;

public partial class RegisterDriverPage : ContentPage
{
	public RegisterDriverPage()
	{
		InitializeComponent();
	}

    private async void createBtn_Clicked(object sender, EventArgs e)
    {
		Driver driver = App.AppRepo.CheckDriverInput(DriverId.Text, Name.Text, Surname.Text, Age.Text, PhoneNum.Text, Address.Text);
		if(driver.Id == 0 ) 
		{
			// we have an empty driver instance
			ErrorMsg.IsVisible = true;
			ErrorMsg.Text = App.AppRepo.StatusMessage;
			return;
		}

		// load existing drivers from database
        List<Driver> drivers = await App.AppRepo.GetAllDrivers();
        foreach (Driver d in drivers) 
		{
			if(d.Id == driver.Id)
			{
				// a driver with the given Id already exists
				ErrorMsg.IsVisible = true;
				ErrorMsg.Text = "The given Id already exists!";
				return;
			}
		}

		// add driver to db
		ErrorMsg.IsVisible = true;
		ErrorMsg.Text = "Driver registered successfully!";
    }
}