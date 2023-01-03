using MyApp.Models;

namespace MyApp;

public partial class EditDriverPage : ContentPage
{ 
	public EditDriverPage()
	{
		InitializeComponent();
	}

    private void editBtn_Clicked(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(DriverId.Text);
        // call LINQ method to return driver with matching Id
        // if driver does not exist, output Error msg

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

        // use UpdateAsync() to update db
        ErrorMsg.IsVisible = true;
        ErrorMsg.Text = "Driver updated successfully!";
    }
}