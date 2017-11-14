using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Data;
using CarDealer.Domain;
using System.Linq;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public class CarService : BaseService, ICarService
    {
        public CarService(CarDealerDbContext _db) : base(_db)
        {
        }

        public IEnumerable<CarModel> CarFromMake(string carMake)
        {
            return db.Cars
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
        }
    }
}
