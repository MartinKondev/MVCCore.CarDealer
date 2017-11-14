using CarDealer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.App.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            var sales = _salesService.GetAllSales();
            return View(sales);
        }
    }
}
