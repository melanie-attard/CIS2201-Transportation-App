using MyApp.Models;

namespace MyApp;

public partial class BusSummaryPage : ContentPage
{
	public BusSummaryPage()
	{
		InitializeComponent();

		List<Route> busesUsed = App.AppRepo.Manager.BusesUsed;
        // grouping by route id, to avoid displaying repeated data
        busSummary.ItemsSource = busesUsed.GroupBy(route => route.Id).Select(bus => bus.FirstOrDefault());

		// aggregate information
		int total = busesUsed.Count;
		info.Text = "Total Buses Used Today: " + total;

		foreach(var group in busesUsed.GroupBy(route => route.Id))
		{
			info.Text += "\nYou used Route " + group.Key + ", " + group.Count() + " time(s).";
		}
	}
}