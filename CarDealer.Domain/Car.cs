namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public Car()
        {
            PartCars = new HashSet<PartCar>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public long TravelledDistance { get; set; }

        public ICollection<PartCar> PartCars { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
