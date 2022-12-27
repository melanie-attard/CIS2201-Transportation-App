using MyApp.Models;

namespace MyApp;

public partial class RegisterDriverPage : ContentPage
{
	List<Driver> drivers = new List<Driver>(); //existing drivers in db
	public RegisterDriverPage()
	{
		InitializeComponent();
	}

    private void createBtn_Clicked(object sender, EventArgs e)
    {
		int id = Convert.ToInt32(DriverId.Text);
		// populate drivers list
		foreach(Driver d in drivers) 
		{
			if(d.Id == id)
			{
				// a driver with the given Id already exists
				ErrorMsg.IsVisible = true;
				ErrorMsg.Text = "The given Id already exists";
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