using MilkProject.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkProject.Business.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerByCode(string customerCode);

        Task<bool> AddCustomer(Customer customer);

        string GetCustomerCode();

        List<Customer> GetAllCustomer();
    }
}
