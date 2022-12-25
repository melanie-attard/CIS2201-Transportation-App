using MyApp.Models;

namespace MyApp;

public partial class UserPage : ContentPage
{
    List<Route> routes;
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

        busSummary.ItemsSource = routes;
        routeList.ItemsSource = routes;
    }

    private async void routeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int Id = (e.CurrentSelection.FirstOrDefault() as Route).Id;
        await Shell.Current.GoToAsync($"routeDetails?routeId={Id}");
    }
}