using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public decimal Discount { get; set; }

        //public decimal Price { get => Car.Parts.Sum(p => p.Part.Price.Value * p.Part.Quantity); }

        //public decimal PriceAfterDiscount { get => Price - Price * Discount; }
    }
}
 