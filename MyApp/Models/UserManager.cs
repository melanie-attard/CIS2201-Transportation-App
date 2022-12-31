namespace MyApp.Models
{
    public class UserManager : User
    {
        public UserManager() 
        {
            Paid = false;
            BusesUsed = new List<Route>();
        }

        public override void EnterBus(Route route)
        {
            BusesUsed.Add(route);
        }
    }
}
