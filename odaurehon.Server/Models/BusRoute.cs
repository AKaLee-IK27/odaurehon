using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class BusRoute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public required string RouteName { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Departure { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public double DistanceKm { get; set; }

        public virtual required IEnumerable<Bus> Buses { get; set; }
    }
}
