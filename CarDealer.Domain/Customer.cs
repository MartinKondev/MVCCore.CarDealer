namespace CarDealer.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
