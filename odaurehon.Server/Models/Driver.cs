using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Driver : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string LicenseNumber { get; set; }

        //public int BusId { get; set; }
        //[ForeignKey("BusId")]
        //public virtual required Bus Bus { get; set; }
    }
}
