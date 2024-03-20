using CustomerMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerIdAsync(int customerId);
        Task<int> AddcreateCustomer(Customer customerModel);
        List<Customer> GetAllCustomers();
    }
}
