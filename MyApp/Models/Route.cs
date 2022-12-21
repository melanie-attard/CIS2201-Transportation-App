using SQLite;

namespace MyApp.Models
{
    public class Route
    {
        [PrimaryKey, Unique, NotNull]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        // navigational properties
        public Bus Bus { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
