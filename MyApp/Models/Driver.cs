using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Driver
    {
        [PrimaryKey, Unique, NotNull]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        [Range(25, 60)]
        public int? Age { get; set; }

        public int? PhoneNo { get; set; }
        public string? Address { get; set; }
        public bool Assigned { get; set; } = false;

        // navigational property
        public Bus Bus { get; set; }
    }
}
