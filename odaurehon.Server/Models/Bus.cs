using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public enum BusStatus
    {
        Available,
        OnRoute,
        OutOfService
    }

    [Table("Buses")]
    public class Bus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(128)")]
        public required string BusNumber { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string? LicensePlate { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [EnumDataType(typeof(BusStatus))]
        public BusStatus Status = BusStatus.Available;

        [Required]
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual required Driver Driver { get; set; }

        [Required]
        public int BusRouteId { get; set; }
        [ForeignKey("BusRouteId")]
        public virtual required BusRoute BusRoute { get; set; }

        public virtual required IEnumerable<Ticket> Tickets { get; set; }
    }
}
