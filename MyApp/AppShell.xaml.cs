﻿namespace MyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("routeDetails", typeof(RouteDetailsPage));
        }
    }
}