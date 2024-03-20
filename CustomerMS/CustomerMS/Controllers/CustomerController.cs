using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CustomerMS.Models;
using System.Threading.Tasks;
using CustomerMS.Repository;
using Microsoft.Extensions.Logging;

namespace CustomerMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;
        private readonly IRequirementsRepository _requirementsRepository;
        public CustomerController(ICustomerRepository customerRepository,
            IRequirementsRepository requirementsRepository, ILogger<CustomerController> logger)
        {
            _requirementsRepository = requirementsRepository;
            _logger = logger;
            _customerRepository = customerRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerInfoById([FromRoute] int customerId)
        {
            _logger.LogInformation("GetCustomerInfoById method start");
            var record = await _customerRepository.GetCustomerIdAsync(customerId);
            _logger.LogInformation("GetCustomerInfoById method end");
            return Ok(record);
        }

        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            _logger.LogInformation("GetCustomer method start");
            List<Customer> customers = _customerRepository.GetAllCustomers();
            _logger.LogInformation("GetCustomer method end");
            return Ok(customers);
        }

        [HttpPost]
        [Route("Createcustomer")]
        public async Task<IActionResult> Createcustomer([FromBody] Customer customerModel)
        {
            _logger.LogInformation("Createcustomer method start");
            var Id = await _customerRepository.AddcreateCustomer(customerModel);
            _logger.LogInformation("Createcustomer method end");
            return Ok(customerModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var details = await _requirementsRepository.GetPropertyAsync();
            return Ok(details);
        }
    }
}
