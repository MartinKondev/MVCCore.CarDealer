namespace CarDealer.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

    }
}
