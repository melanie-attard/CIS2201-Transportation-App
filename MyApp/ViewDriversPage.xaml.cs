using MyApp.Models;

namespace MyApp;

public partial class ViewDriversPage : ContentPage
{
	List<Driver> drivers = new()
	{
		new Driver()
		{
			Id= 1,
			Name= "John",
			Surname = "Doe",
			Age= 30,
			PhoneNo = 123456,
			Address = "Rose Bush Str., Gozo",
			Assigned = true
		},
		new Driver()
		{
			Id= 2,
            Name= "Jane",
            Surname = "Doe",
            Age= 50,
            PhoneNo = 987456,
            Address = "Rose Bush Str., Gozo",
            Assigned = false
        }
	};
	public ViewDriversPage()
	{
		InitializeComponent();

		viewDrivers.ItemsSource = drivers;
	}
}