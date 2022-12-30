using MyApp.Models;

namespace MyApp;

public partial class ViewDriversPage : ContentPage
{
	
	public ViewDriversPage()
	{
		InitializeComponent();
		UpdateUI();
	}

    private async void UpdateUI()
    {
        List<Driver> drivers = await App.AppRepo.GetAllDrivers();
        viewDrivers.ItemsSource = drivers;
    }
}