namespace MyApp;

public partial class BusSummaryPage : ContentPage
{
	public BusSummaryPage()
	{
		InitializeComponent();
		// grouping by route id, so we do not display repeated data.
		busSummary.ItemsSource = App.AppRepo.Manager.BusesUsed.GroupBy(route => route.Id).Select(bus => bus.FirstOrDefault());
	}
}