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
		int id = App.AppRepo.CheckID(DriverId.Text);
		if(id == 0)
		{
            ErrorMsg.IsVisible = true;
            ErrorMsg.Text = App.AppRepo.StatusMessage;
            return;
        }

		// load existing drivers from database
        List<Driver> drivers = await App.AppRepo.GetAllDrivers();
        foreach (Driver d in drivers) 
		{
			if(d.Id == id)
			{
				// a driver with the given Id already exists
				ErrorMsg.IsVisible = true;
				ErrorMsg.Text = "The given Id already exists!";
				return;
			}
		}

		string name = Name.Text;
		string surname = Surname.Text;
		int age = Convert.ToInt32(Age.Text);
		int phoneNum = Convert.ToInt32(PhoneNum.Text);
		string address = Address.Text;

		// run through checkInput() and output any errors
		Driver driver = new()
		{
			Id = id,
			Name = name,
			Surname = surname,
			Age = age,
			PhoneNo = phoneNum,
			Address = address
		};

		// add driver to db
		ErrorMsg.IsVisible = true;
		ErrorMsg.Text = "Driver registered successfully!";
    }
}