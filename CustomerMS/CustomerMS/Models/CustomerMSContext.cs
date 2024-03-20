using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Models
{
    public class CustomerMSContext : DbContext, ICustomerMSContext
    {
        public CustomerMSContext(DbContextOptions<CustomerMSContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
