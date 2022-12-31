namespace MyApp.Models
{
    public abstract class User
    {
        public List<Route> BusesUsed { get; set; }
        public bool Paid { get; set; }
        public abstract void EnterBus(Route route);
    }
}
