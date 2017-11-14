using CarDealer.App.Models;
using CarDealer.Domain;
using CarDealer.Services;
using CarDealer.Services.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.App.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService service)
        {
            _customerService = service;
        }

        //GET
        //Customer/{id}
        public IActionResult Index(int id)
        {
            var result = _customerService.GetCustomerWithBuysById(id);
            return View(result);
        }

        //GET
        //Customer/all
        public IActionResult All(SortOrder sortOrder)
        {
            var result = _customerService.OrderedCustomers(sortOrder);
            return View(new AllCustomersModel
            {
                Customers = result,
                SortOrder = sortOrder
            });
        }
    }
}
