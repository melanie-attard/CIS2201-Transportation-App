using SQLite;

namespace MyApp.Models
{
    public class BusStop
    {
        [PrimaryKey, Unique, NotNull]
        public int Id { get; set; }

        [Unique, NotNull]
        public string Name { get; set; }

        [NotNull]
        public int Longitude { get; set; }

        [NotNull]
        public int Latitude { get; set; }

        // navigational property
        public ICollection<Schedule> Schedules { get; set; }
    }
}
