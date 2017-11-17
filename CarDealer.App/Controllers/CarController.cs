using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [Route("Cars")]
    public class CarController : Controller
    {
        private readonly ICarService _carSevice;

        public CarController(ICarService carService)
        {
            _carSevice = carService;
        }

        //GET
        //Car/Index
        [Route("")]
        public IActionResult Index()
        {
            var cars = _carSevice.GetAllCars();
            return View("List", cars);
        }

        //GET
        //Car/CarsFromMake(string make)
        [Route("CarsFromMake/{make}")]
        public IActionResult CarsFromMake(string make)
        {
            var cars = _carSevice.GetCarFromMake(make);
            return View(cars);
        }

        //GET
        //Car/Parts/id()
        [Route("Parts/{id}")]
        public IActionResult Parts(int id)
        {
            var cars = _carSevice.GetCarWithItsPartsById(id);
            return View(cars);
        }
    }
}
