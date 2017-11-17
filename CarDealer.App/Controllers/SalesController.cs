using CarDealer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.App.Controllers
{
    [Route("Sales")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var sales = _salesService.GetAllSales();
            return View(sales);
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var sale = _salesService.GetSaleById(id);
            return View("Sale", sale);
        }
    }
}
