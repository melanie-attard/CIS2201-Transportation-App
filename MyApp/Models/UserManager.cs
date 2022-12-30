namespace MyApp.Models
{
    public class UserManager : User
    {
        public UserManager() 
        {
            paid = false;
        }

        public override void EnterBus(Bus bus)
        {
            busesUsed.Add(bus);
        }
    }
}
