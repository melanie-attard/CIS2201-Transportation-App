using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Schedule
    {
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }
        public string Time4 { get; set; }
        public string Time5 { get; set; }
        public string Time6 { get; set; }

        // navigational properties
        [ForeignKey("route"), NotNull]
        public int RouteId { get; set; }
        //public Route route { get; set; }

        [ForeignKey("busStop"), NotNull]
        public int StopId { get; set; }
        //public BusStop busStop { get; set; }
    }
}
