namespace MyApp;

public partial class UserManagerPage : ContentPage
{
	public UserManagerPage()
	{
		InitializeComponent();

        if (App.AppRepo.manager.Paid == true)
        {
            paymentStats.Text = "PAID";
        }
    }

    private void payBtn_Clicked(object sender, EventArgs e)
    {
		if(App.AppRepo.manager.Paid == false)
		{
            App.AppRepo.manager.Paid = true;
			paymentStats.Text = "PAID";
        }
		
    }
}