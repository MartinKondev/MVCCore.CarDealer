using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public int Car_Id { get; set; }
        [Required]
        public virtual Car Car { get; set; }

        public int Customer_Id { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public double Discount { get; set; }
    }
}
 