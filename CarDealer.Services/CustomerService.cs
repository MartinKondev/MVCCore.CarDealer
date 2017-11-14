using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Enums;
using CarDealer.Data;
using System.Linq;
using CarDealer.Domain;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(CarDealerDbContext _db) : base(_db)
        {
        }

        public CustomerWithBuysModel GetCustomerWithBuysById(int id)
        {
            return db
                .Customers
                .Where(c => c.Id == id)
                .Select(customer =>
                    new CustomerWithBuysModel
                    {
                        Name = customer.Name,
                        BoughtCarsCount = customer.Sales.Count(),
                        TotalMoneySpent = customer.Sales.Sum(s => s.Car.Parts.Sum(p => (p.Part.Price - p.Part.Price * s.Discount))).Value
                    })
                    .FirstOrDefault();             
        }

        private void sumParts(ref decimal sum, Part p)
        {
            sum += p.Quantity * p.Price.Value;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(SortOrder sortOrder)
        {
            var customersQuery = db.Customers.AsQueryable();
            switch (sortOrder)
            {
                case SortOrder.accending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver);
                    break;
                case SortOrder.descending:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.IsYoungDriver);
                    break;
                default:
                    break;

            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }
    }
}
