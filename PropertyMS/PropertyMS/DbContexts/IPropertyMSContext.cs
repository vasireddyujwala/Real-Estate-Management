using Microsoft.EntityFrameworkCore;
using PropertyMS.Models;
using System.Threading.Tasks;

namespace PropertyMS.DbContexts
{
    public interface IPropertyMSContext
    {
        DbSet<Properties> Properties { get; set; }

        Task<int> SaveChanges();
    }
}