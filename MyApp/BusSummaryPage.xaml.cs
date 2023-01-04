namespace MyApp;

public partial class BusSummaryPage : ContentPage
{
	public BusSummaryPage()
	{
		InitializeComponent();
		busSummary.ItemsSource = App.AppRepo.Manager.BusesUsed;
	}
}