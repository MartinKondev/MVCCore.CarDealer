using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Domain
{
    public class PartCar
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
