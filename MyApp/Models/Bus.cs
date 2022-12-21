using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Bus
    {
        [PrimaryKey, Unique, NotNull]
        public int BusId { get; set; }

        [NotNull]
        public int Capacity { get; set; }

        public bool Assigned { get; set; } = false;

        // navigational properties
        [ForeignKey("route")]
        public int RouteId { get; set; }
        public Route route { get; set; }

        [ForeignKey("driver")]
        public int DriverId { get; set; }
        public Driver driver { get; set; }
    }
}
