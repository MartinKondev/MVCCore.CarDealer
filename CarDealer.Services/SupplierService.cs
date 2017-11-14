﻿using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Data;
using CarDealer.Services.Models;
using System.Linq;

namespace CarDealer.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public SupplierService(CarDealerDbContext _db) : base(_db)
        {
        }

        public IEnumerable<SupplierModel> GetSuppliers(string type)
        {
            var suppliers = db
                .Suppliers
                .AsQueryable();

            switch (type)
            {
                case "Local":
                    suppliers = suppliers.Where(s => !s.IsImporter);
                    break;
                case "Importer":
                    suppliers = suppliers.Where(s => s.IsImporter);
                    break;
                default:
                    break;
            }

            var result = suppliers.Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name,
                PartsNumber = s.Parts.Count()
            });

            return result;
        }
    }
}