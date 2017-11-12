using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        [Required]
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public double Discount { get; set; }
    }
}
 