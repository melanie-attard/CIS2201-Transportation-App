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
        List<Driver> unassigned = drivers.Where(d => d.Assigned == false).ToList();
        unassignedDrivers.ItemsSource = unassigned;

        List<Driver> assigned = drivers.Where(d => d.Assigned == true).ToList();
        List<Bus> buses = await App.AppRepo.GetAllBuses();
        // adding route Id to assigned drivers
        var combined = assigned.Join(buses, driver => driver.Id, bus => bus.DriverId, (assigned, buses) => new
        {
            assigned.Id,
            assigned.Name,
            assigned.Surname,
            assigned.Age,
            assigned.PhoneNo,
            assigned.Address,
            assigned.Assigned,
            buses.RouteId
        }).ToList();
        assignedDrivers.ItemsSource = combined;
    }
}