using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class SalesModel
    {
        public CarModel Car { get; set; }

        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get => Price - Price * Discount; }
    }
}
