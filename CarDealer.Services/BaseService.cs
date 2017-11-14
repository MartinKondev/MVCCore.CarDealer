using CarDealer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public class BaseService
    {
        protected readonly CarDealerDbContext db;

        public BaseService(CarDealerDbContext _db)
        {
            db = _db;
        }
    }
}
