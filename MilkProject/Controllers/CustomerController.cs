using Microsoft.AspNetCore.Mvc;
using MilkProject.Business.Services;
using MilkProject.DB.Entity;
using MilkProject.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MilkProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomerByCode/{customerCode}")]
        public ActionResult GetCustomerByCode(string customerCode)
        {
            var result = _customerService.GetCustomerByCode(customerCode);
            if (result == null)
                return Ok(new { status = 0, message = "invaid customer code" });
            return Ok(new { status = 1, data = result });
        }

        [HttpGet("GetCustomers")]
        public ActionResult GetCustomers()
        {
            var result = _customerService.GetAllCustomer();
            if (result == null)
                return Ok(new { status = 0, message = "invaid customer code" });
            return Ok(new { status = 1, data = result });
        }

        [HttpPost("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer(CustomerModel customer)
        {
            var customerInfo = new Customer()
            {
                CustomerName = customer.CustomerName,
                IsActive = customer.IsActive,
                PhoneNumber = customer.PhoneNumber,
                StreetName = customer.StreetName,
                Village = customer.Village,
            };
            var result = await _customerService.AddCustomer(customerInfo);
            if (!result)
                return Ok(new { status = 0, message = "invaid customer data" });
            return Ok(new { status = 1, data = result });
        }

        [HttpGet("GetCustomerCode")]
        public ActionResult GetCustomerCode()
        {
            var result = _customerService.GetCustomerCode();
            if (string.IsNullOrWhiteSpace(result))
                return Ok(new { status = 0, message = "invaid data" });
            return Ok(new { status = 1, data = result });
        }

    }
}
