using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public enum PaymentMethod
    {
        OnlineBanking,
        Cash
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }

    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public required string PaymentAmount { get; set; }

        [Required]
        public PaymentMethod? PaymentMethod { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [Required]
        public DateTime PaidDate { get; set; }

        //public int BookingId { get; set; }
        //[ForeignKey("BookingId")]
        //public virtual required Booking Booking { get; set; }
    }
}
