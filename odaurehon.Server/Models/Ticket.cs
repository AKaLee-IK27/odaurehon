using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public enum TicketStatus
    {
        Available,
        Booked,
    }

    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int SeatNumber { get; set; }
        public float Price { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Available;

        [Required]
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public virtual required Booking Booking { get; set; }

        [Required]
        public int BusId { get; set; }
        [ForeignKey("BusId")]
        public virtual required Bus Bus { get; set; }

    }
}
