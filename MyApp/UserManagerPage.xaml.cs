namespace MyApp;

public partial class UserManagerPage : ContentPage
{
	public UserManagerPage()
	{
		InitializeComponent();
	}

    private void payBtn_Clicked(object sender, EventArgs e)
    {
		App.AppRepo.manager.Paid = true;
    }
}