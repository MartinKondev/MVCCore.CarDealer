using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carSevice;

        public CarController(ICarService carService)
        {
            _carSevice = carService;
        }

        //GET
        public IActionResult CarsFromMake(string make)
        {
            var cars = _carSevice.CarFromMake(make);
            return View(cars);
        }
    }
}
