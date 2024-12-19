using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalGraphQL.Models
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int RenterId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        [ForeignKey("RenterId")]
        public Renter Renter { get; set; }
    }
}
