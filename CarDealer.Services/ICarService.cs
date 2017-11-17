using CarDealer.Domain;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> GetAllCars();

        IEnumerable<CarModel> GetCarFromMake(string carMake);

        IEnumerable<CarWithItsPartsModel> GetCarWithItsPartsById(int Id);
    }
}
