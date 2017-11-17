using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Data;
using CarDealer.Domain;
using System.Linq;
using CarDealer.Services.Models;
using System.Reflection;

namespace CarDealer.Services
{
    public class CarService : BaseService, ICarService
    {
        public CarService(CarDealerDbContext _db) : base(_db)
        {
        }

        public IEnumerable<CarModel>GetAllCars()
        {
            var cars = db.Cars.Select(c => new CarModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            })
            .ToList();

            return cars;
        }

        public IEnumerable<CarWithItsPartsModel> GetCarWithItsPartsById(int Id)
        {
            var cars = db.Cars
                .Select(c => new CarWithItsPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartBasicModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .ToList()
                })
                .ToList();
            return cars;
        }

        public IEnumerable<CarModel> GetCarFromMake(string carMake)
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
