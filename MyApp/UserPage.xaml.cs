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
    }
}