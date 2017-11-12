using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain
{
    public class PartCar
    {
        public int Car_Id { get; set; }
        public Car Car { get; set; }

        public int Part_Id { get; set; }
        public Part Part { get; set; }
    }
}
