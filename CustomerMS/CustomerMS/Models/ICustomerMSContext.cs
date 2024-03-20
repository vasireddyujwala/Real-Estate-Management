using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerMS.Models
{
    public interface ICustomerMSContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Properties> Properties { get; set; }
        DbSet<Requirement> Requirements { get; set; }

        Task<int> SaveChanges();
    }
}