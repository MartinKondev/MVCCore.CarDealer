using CarDealer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.App.Enums;

namespace CarDealer.App.Controllers
{
    public class SuppliersController : Controller
    {
        protected readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index(SupplierTypeEnum supplierType)
        {
            return View(_supplierService.GetSuppliers(supplierType.ToString()));
        }
    }
}
