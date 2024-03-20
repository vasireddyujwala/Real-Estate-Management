using CustomerMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerMSContext _context;

        public CustomerRepository(CustomerMSContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerIdAsync(int customerId)
        {
            var CustomerDetails = await _context.Customers.Where(x => x.CustomerId == customerId).Select(x => new Customer()
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Locality = x.Locality,
                ContactNo = x.ContactNo,
                EmailId = x.EmailId,
                Requirement = x.Requirement,

            }).FirstOrDefaultAsync();
            return CustomerDetails;
        }
        public async Task<int> AddcreateCustomer(Customer customerModel)
        {
            var Data = new Customer()
            {
                CustomerId = customerModel.CustomerId,
                Name = customerModel.Name,
                Locality = customerModel.Locality,
                ContactNo = customerModel.ContactNo,
                Requirement = customerModel.Requirement,
                EmailId = customerModel.EmailId,
            };
            _context.Customers.Add(Data);
            await _context.SaveChangesAsync();
            return Data.CustomerId;

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();
            return customers;
        }
    }
}
