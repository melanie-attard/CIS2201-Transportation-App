namespace MyApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //UserBtn.Clicked += async (s, e) => await Shell.Current.GoToAsync("userpage");
        }

        private void OnUserClicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(UserBtn.Text);
            Shell.Current.FlyoutIsPresented = true;
            // retrieved from https://github.com/dotnet/maui/issues/10037
            Shell.Current.CurrentPage.Layout(new Rect(0, 0, Shell.Current.CurrentPage.Width + 1, Shell.Current.CurrentPage.Height + 1));
        }

        private void OnDriverClicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(DriverBtn.Text);
            Shell.Current.FlyoutIsPresented = true;
            // retrieved from https://github.com/dotnet/maui/issues/10037
            Shell.Current.CurrentPage.Layout(new Rect(0, 0, Shell.Current.CurrentPage.Width + 1, Shell.Current.CurrentPage.Height + 1));
        }
    }
}