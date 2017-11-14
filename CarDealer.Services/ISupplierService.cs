using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSuppliers(bool isLocal);
    }
}
