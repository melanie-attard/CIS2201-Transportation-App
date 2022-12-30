namespace MyApp.Models
{
    public abstract class User
    {
        public List<Bus> busesUsed { get; set; }
        public bool paid { get; set; }
        public abstract void EnterBus(Bus bus);
    }
}
