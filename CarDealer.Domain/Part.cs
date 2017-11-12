namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            PartCars = new HashSet<PartCar>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<PartCar> PartCars { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
