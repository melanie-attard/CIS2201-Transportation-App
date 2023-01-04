namespace MyApp;

public partial class UserManagerPage : ContentPage
{
	public UserManagerPage()
	{
		InitializeComponent();

        if (App.AppRepo.Manager.Paid == true)
        {
            paymentStats.Text = "PAID";
        }
    }

    private void payBtn_Clicked(object sender, EventArgs e)
    {
		if(App.AppRepo.Manager.Paid == false)
		{
            App.AppRepo.Manager.Paid = true;
			paymentStats.Text = "PAID";
        }
		
    }
}