using MyApp.Models;

namespace MyApp;

public partial class UserPage : ContentPage
{
    public UserPage()
    {
        InitializeComponent();
        UpdateUI(); 
    }

    private async void UpdateUI()
    {
        busSummary.ItemsSource = App.AppRepo.manager.BusesUsed;

        List<Route> routes = await App.AppRepo.GetAllRoutes();
        if(routes != null) { routeList.ItemsSource = routes; }
        
        List<BusStop> busStops = await App.AppRepo.GetAllStops();
        if (busStops != null) { stopsList.ItemsSource = busStops; }
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