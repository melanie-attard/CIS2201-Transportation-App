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

        public bool DisabilitySupport { get; set; }

        public bool Assigned { get; set; }

        // navigational properties
        [ForeignKey("Route"), Unique]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        [ForeignKey("Driver"), Unique]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
