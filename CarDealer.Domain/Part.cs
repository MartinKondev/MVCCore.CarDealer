namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            Cars = new HashSet<PartCar>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<PartCar> Cars { get; set; }

        public int Supplier_Id { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
