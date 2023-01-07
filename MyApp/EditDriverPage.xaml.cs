using MyApp.Models;

namespace MyApp;

public partial class EditDriverPage : ContentPage
{ 
	public EditDriverPage()
	{
		InitializeComponent();
	}

    private async void editBtn_Clicked(object sender, EventArgs e)
    {
        Driver driver = App.AppRepo.CheckDriverInput(DriverId.Text, Name.Text, Surname.Text, Age.Text, PhoneNum.Text, Address.Text);
        if (driver.Id == 0)
        {
            // we have an empty driver instance
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = App.AppRepo.StatusMessage;
            return;
        }

        // get driver with matching Id
        Driver driver1 = await App.AppRepo.GetDriverById(driver.Id);
        if(driver1 == null)
        {
            // driver does not exist
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = "The given Id does not exist!";
            return;
        }
        
        if(driver1.Assigned == true)
        {
            driver.Assigned = true; //otherwise assigned will be set to false
        }

        // update db instance
        await App.AppRepo.UpdateDriverAsync(driver);
        ErrorMsg.IsVisible = true;
        ErrorMsg.Text = "Driver updated successfully!";
    }
}