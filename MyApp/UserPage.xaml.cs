using MyApp.Models;

namespace MyApp;

public partial class UserPage : ContentPage
{
    List<Route> routes;
    List<BusStop> busStops;
    public UserPage()
    {
        InitializeComponent();

        routes = new List<Route>() 
        {
            new Route()
            {
                Id = 51,
                Name = "Mtarfa-Valletta"
            }
        };

        busStops= new List<BusStop>()
        {
            new BusStop()
            {
                Id= 1,
                Name = "Dumnikani",
                Latitude = 1234,
                Longitude = 9876
            }
        };

        busSummary.ItemsSource = routes;
        routeList.ItemsSource = routes;
        stopsList.ItemsSource = busStops;
    }

    private async void routeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if((e.CurrentSelection.FirstOrDefault() as Route) != null)
        {
            int Id = (e.CurrentSelection.FirstOrDefault() as Route).Id;
            await Shell.Current.GoToAsync($"routeDetails?routeId={Id}");
            routeList.SelectedItem = null;
        }
    }

    private async void stopsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if ((e.CurrentSelection.FirstOrDefault() as BusStop) != null)
        {
            string name = (e.CurrentSelection.FirstOrDefault() as BusStop).Name;
            await Shell.Current.GoToAsync($"stopDetails?stopName={name}");
            stopsList.SelectedItem = null;
        }
    }
}