using CarDealer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.App.Controllers
{
    public class SuppliersController : Controller
    {
        protected readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Local()
        {
            return View("Index", _supplierService.GetSuppliers(true));
        }

        public IActionResult Importers()
        {
            return View("Index", _supplierService.GetSuppliers(false));
        }
    }
}
