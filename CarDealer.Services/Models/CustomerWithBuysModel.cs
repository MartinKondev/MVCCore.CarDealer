using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CustomerWithBuysModel : CustomerModel
    {
        public int BoughtCarsCount { get; set; }

        public decimal TotalMoneySpent { get; set; }
    }
}
