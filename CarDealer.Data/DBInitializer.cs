using CarDealer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data
{
    public class DBInitializer
    {
        private CarDealerDbContext context;
        private static int firstCarId;
        private static int firstCustomerId;
        private static int firstSaleId;
        private static int firstSupplierId;
        private static int firstPartId;

        public DBInitializer(CarDealerDbContext _context)
        {
            context = _context;
        }

        public async Task Seed()
        {   
            if (!context.Cars.Any())
            {
                await context.AddRangeAsync(_cars());
                await context.SaveChangesAsync();
            }
            firstCarId = context.Cars.First().Id;

            if (!context.Customers.Any())
            {
                await context.AddRangeAsync(_customers());
                await context.SaveChangesAsync();
            }
            firstCustomerId = context.Customers.First().Id;

            if (!context.Sales.Any())
            {
                await context.AddRangeAsync(_sales());
                await context.SaveChangesAsync();
            }
            firstSaleId = context.Sales.First().Id;

            if (!context.Suppliers.Any())
            {
                await context.AddRangeAsync(_suppliers());
                await context.SaveChangesAsync();
            }
            firstSupplierId = context.Suppliers.First().Id;

            if (!context.Parts.Any())
            {
                await context.AddRangeAsync(_parts());
                await context.SaveChangesAsync();
            }
            firstPartId = context.Parts.First().Id;

            if (!context.PartCars.Any())
            {
                await context.AddRangeAsync(_partCars());
                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<Car> _cars()
        {
            return new List<Car>
            {
                new Car{Make="Opel", Model="Omega", TravelledDistance=27816553423},
                new Car{Make="Opel", Model="Astra", TravelledDistance=9123421312341123},
                new Car{Make="Opel", Model="Astra", TravelledDistance=3214341234123},
                new Car{Make="Opel", Model="Corsa", TravelledDistance=123412341241},
                new Car{Make="Opel", Model="Kadet", TravelledDistance=54634572463456},
                new Car{Make="Opel", Model="Omega", TravelledDistance=56745673634567},
                new Car{Make="Opel", Model="Astra", TravelledDistance=23453456},
                new Car{Make="Audi", Model="AstraInsignia", TravelledDistance=345},
                new Car{Make="Ferarri", Model="Kadet", TravelledDistance=345635463546},
                new Car{Make="Reno", Model="Kadet", TravelledDistance=45674674567},
                new Car{Make="Peugeot", Model="Kadet", TravelledDistance=45674567},
                new Car{Make="Lada", Model="Samara", TravelledDistance=45674567456745674}
            };
        }

        public IEnumerable<Customer> _customers()
        {
            return new List<Customer>
            {
                new Customer{Name="Emmitt Benally", BirthDate=new DateTime(1993, 11, 20), IsYoungDriver = true },
                new Customer{Name="Natalie Poli", BirthDate=new DateTime(1993, 11, 20), IsYoungDriver = false },
                new Customer{Name="Marcelle Griego", BirthDate=new DateTime(1993, 10, 04), IsYoungDriver = true },
                new Customer{Name="Zada Attwood", BirthDate=new DateTime(1983, 10, 2), IsYoungDriver = false },
                new Customer{Name="Hai Everton", BirthDate=new DateTime(1998, 1, 20), IsYoungDriver = false },
                new Customer{Name="", BirthDate=new DateTime(1997, 1, 2), IsYoungDriver = true }
            };
        }

        public IEnumerable<Sale> _sales()
        {
            return new List<Sale>
            {
                new Sale { Discount = 0.3m, Car_Id = firstCarId, Customer_Id = firstCustomerId + 1 },
                new Sale { Discount = 0.2m, Car_Id = firstCarId + 1, Customer_Id = firstCustomerId + 2 },
                new Sale { Discount = 0.4m, Car_Id = firstCarId + 2, Customer_Id = firstCustomerId + 3 },
                new Sale { Discount = 0.25m, Car_Id = firstCarId + 3, Customer_Id = firstCustomerId + 4 },
                new Sale { Discount = 0.10m, Car_Id = firstCarId + 4, Customer_Id = firstCustomerId + 5 },
                new Sale { Discount = 0.13m, Car_Id = firstCarId + 5, Customer_Id = firstCustomerId + 0 },
                new Sale { Discount = 0.15m, Car_Id = firstCarId + 6, Customer_Id = firstCustomerId + 1 },
                new Sale { Discount = 0.30m, Car_Id = firstCarId + 8, Customer_Id = firstCustomerId + 2 },
                new Sale { Discount = 0.2m, Car_Id = firstCarId + 9, Customer_Id = firstCustomerId + 3 },
                new Sale { Discount = 0.1m, Car_Id = firstCarId + 5, Customer_Id = firstCustomerId + 4 },
                new Sale { Discount = 0.2m, Car_Id = firstCarId + 7, Customer_Id = firstCustomerId + 5 },
                new Sale { Discount = 0.51m, Car_Id = firstCarId, Customer_Id = firstCustomerId + 0 },
            };
        }

        public IEnumerable<Supplier> _suppliers()
        {
            return new List<Supplier>
            {
                new Supplier{ Name = "3M Company", IsImporter = false},
                new Supplier{ Name = "Agway Inc.", IsImporter = false},
                new Supplier{ Name = "Anthem, Inc.", IsImporter = false},
                new Supplier{ Name = "Airgas, Inc.", IsImporter = false},
                new Supplier{ Name = "Casey''s General Stores Inc.", IsImporter = false},
                new Supplier{ Name = "Dedo pesho", IsImporter = false},
                new Supplier{ Name = "Gorublqn", IsImporter = true},
                new Supplier{ Name = "Joe Peshi", IsImporter = true},
                new Supplier{ Name = "Chubb Corp", IsImporter = true},
                new Supplier{ Name = "Olin Corp.", IsImporter = true},
                new Supplier{ Name = "Asdf Corporation", IsImporter = true},
                new Supplier{ Name = "Qwer Corporation", IsImporter = true},
                new Supplier{ Name = "Saks Inc", IsImporter = true},
            };
        }

        public IEnumerable<Part> _parts()
        {
            return new List<Part>
            {
                new Part{ Name = "Bonnet/hood", Price = 10, Quantity = 2, Supplier_Id = firstSupplierId },
                new Part{ Name = "Unexposed bumper", Price = 20, Quantity = 2, Supplier_Id = firstSupplierId + 2 },
                new Part{ Name = "Fascia", Price = 30, Quantity = 12, Supplier_Id = firstSupplierId + 3 },
                new Part{ Name = "Rims", Price = 40, Quantity = 1, Supplier_Id = firstSupplierId + 4 },
                new Part{ Name = "Gaika", Price = 50, Quantity = 34, Supplier_Id = firstSupplierId + 5 },
                new Part{ Name = "Shasi", Price = 34, Quantity = 26, Supplier_Id =firstSupplierId +  6 },
                new Part{ Name = "Valance", Price = 650, Quantity = 12, Supplier_Id = firstSupplierId + 7 },
                new Part{ Name = "Fuel tank", Price = 3450, Quantity = 22, Supplier_Id = firstSupplierId + 8 },
                new Part{ Name = "Front Right Side Door Glass", Price = 1200, Quantity = 82, Supplier_Id = firstSupplierId + 9 },
                new Part{ Name = "Back Left Side Door Glass", Price = 1100, Quantity = 12, Supplier_Id = firstSupplierId + 10 },
            };
        }

        public IEnumerable<PartCar> _partCars()
        {
            return new List<PartCar>
            {
                new PartCar{Part_Id = firstPartId + 1, Car_Id = firstCarId +  1},
                new PartCar{Part_Id = firstPartId + 2, Car_Id = firstCarId +  2},
                new PartCar{Part_Id = firstPartId + 3, Car_Id = firstCarId +  3},
                new PartCar{Part_Id = firstPartId + 4, Car_Id = firstCarId +  4},
                new PartCar{Part_Id = firstPartId + 5, Car_Id = firstCarId +  5},
                new PartCar{Part_Id = firstPartId + 6, Car_Id = firstCarId +  6},
                new PartCar{Part_Id = firstPartId + 7, Car_Id = firstCarId +  7},
                new PartCar{Part_Id = firstPartId + 1, Car_Id = firstCarId +  2},
                new PartCar{Part_Id = firstPartId + 2, Car_Id = firstCarId +  4},
                new PartCar{Part_Id = firstPartId + 3, Car_Id = firstCarId +  1},
                new PartCar{Part_Id = firstPartId + 4, Car_Id = firstCarId +  5},
                new PartCar{Part_Id = firstPartId + 5, Car_Id = firstCarId +  3},
                new PartCar{Part_Id = firstPartId + 6, Car_Id = firstCarId +  10},
                new PartCar{Part_Id = firstPartId, Car_Id = firstCarId}
            };
        }

        private void ResetDb(CarDealerDbContext _context)
        {
            var deleteCommand = "DELETE FROM dbo.{0} ";
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "Cars"));
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "Customers"));
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "Suppliers"));
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "Sales"));
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "Parts"));
            _context.Database.ExecuteSqlCommand(string.Format(deleteCommand, "PartCars"));
        }
    }
}