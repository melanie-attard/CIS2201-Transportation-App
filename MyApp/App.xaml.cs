namespace MyApp
{
    public partial class App : Application
    {
        public static AppRepository AppRepo { get; set; }
        public App(AppRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Initialise the AppRepository property with the AppRepository singleton object
            AppRepo = repo;
        }
    }
}