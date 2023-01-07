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
        public string Longitude { get; set; }

        [NotNull]
        public string Latitude { get; set; }
    }
}
