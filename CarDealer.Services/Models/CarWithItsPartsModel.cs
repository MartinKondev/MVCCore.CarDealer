using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CarWithItsPartsModel : CarModel
    {
        public IEnumerable<PartBasicModel> Parts { get; set; }
    }
}
