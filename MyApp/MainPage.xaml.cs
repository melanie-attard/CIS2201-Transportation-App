namespace MyApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnUserClicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(UserBtn.Text);
        }

        private void OnDriverClicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(DriverBtn.Text);
        }
    }
}