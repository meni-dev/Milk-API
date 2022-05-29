using MilkProject.DB;
using MilkProject.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkProject.Business.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly MilkDbContext _milkDbContext;
        public CustomerService(MilkDbContext milkDbContext)
        {
            _milkDbContext = milkDbContext;
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            return _milkDbContext.Customer.FirstOrDefault(x => x.CustomerCode == customerCode);
        }

        public List<Customer> GetAllCustomer()
        {
            return _milkDbContext.Customer.ToList();
        }


        public async Task<bool> AddCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                    return false;

                var customerId = _milkDbContext.Customer.DefaultIfEmpty().Max(x => x.CustomerId == null ? 0 : x.CustomerId);
                customer.CustomerCode = "M" + (customerId == 0 ? 1 : customerId + 1).ToString().PadLeft(4, '0');
                _milkDbContext.Customer.Add(customer);

                await _milkDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }

        }

        public string GetCustomerCode()
        {
            var code = _milkDbContext.Customer.DefaultIfEmpty().Max(x => x.CustomerId == null ? 0 : x.CustomerId);
            if (code == 0)
                return "M0001";
            return "M" + (code + 1).ToString().PadLeft(4, '0');
        }
    }
}
