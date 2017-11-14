using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface ISalesService
    {
        IEnumerable<SalesModel> GetAllSales();

        SalesModel GetSaleById(int id);

        IEnumerable<SalesModel> GetDiscountedSales();

        IEnumerable<SalesModel> GetDiscountedSalesByCertainPercent(decimal percent);

    }
}
