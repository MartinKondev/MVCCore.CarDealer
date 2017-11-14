using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Data;
using System.Linq; 

namespace CarDealer.Services
{
    public class SalesService : BaseService, ISalesService
    {
        public SalesService(CarDealerDbContext _db) : base(_db)
        {
        }

        public IEnumerable<SalesModel> GetAllSales()
        {
            var sales = db.Sales.Select(s => new SalesModel
            {
                Car = new CarModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                CustomerName = s.Customer.Name,
                Price = s.Car.Parts.Sum(p => p.Part.Price.Value * p.Part.Quantity),
                Discount = s.Discount
            });

            sales.ForEach(s => s.Price = s.Price - s.Price * s.Discount);

            return sales;
        }

        public SalesModel GetSaleById(int id)
        {
            return db
                .Sales
                .Where(s => s.Id == id)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price.Value * p.Part.Quantity),
                    Discount = s.Discount
                })
                .FirstOrDefault();
        }

        public IEnumerable<SalesModel> GetDiscountedSales()
        {
            var sales = db
                .Sales
                .Where(s => s.Discount > 0m)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price.Value * p.Part.Quantity),
                    Discount = s.Discount
                })
                .ToList();

            sales.ForEach(s => s.Price = s.Price - s.Price * s.Discount);
            return sales;

        }

        public IEnumerable<SalesModel> GetDiscountedSalesByCertainPercent(decimal percent)
        {
            var sales = db
                .Sales
                .Where(s => s.Discount == percent)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Sum(p => p.Part.Price.Value * p.Part.Quantity),
                    Discount = s.Discount
                })
                .ToList();

            sales.ForEach(s => s.Price = s.Price - s.Price * s.Discount);

            return sales;
        }

    }
}
