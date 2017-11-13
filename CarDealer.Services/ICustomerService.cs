using CarDealer.Services.Enums;
using CarDealer.Services.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IList<CustomerModel> OrderedCustomers(SortOrder sortOrder);
    }
}
