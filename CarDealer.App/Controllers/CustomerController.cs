using CarDealer.App.Models;
using CarDealer.Domain;
using CarDealer.Services;
using CarDealer.Services.Enums;
using CarDealer.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.App.Controllers
{
    [Route("Customer")]
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
        //Customer/all/...
        [Route("")]
        [Route("All/accending")]
        [Route("All/deccending")]
        public IActionResult All(SortOrder sortOrder = SortOrder.accending)
        {
            var result = _customerService.OrderedCustomers(sortOrder);
            return View(new AllCustomersModel
            {
                Customers = result,
                SortOrder = sortOrder
            });
        }

        //GET
        //Customer/Add
        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //POST
        //Customer/Add
        [Route("Add")]
        [HttpPost]
        public IActionResult Add(CustomerModel model)
        {
            _customerService.AddCustomer(model);
            return RedirectToAction("All");
        }

        //GET
        //Customer/Edit/{id}
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            return View(customer);
        }

        //PUT
        //Customer/Edit/{model}
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, CustomerModel model)
        {
            var edited =_customerService.EditCustomer(model);
            return RedirectToAction("All");
        }
    }
}
