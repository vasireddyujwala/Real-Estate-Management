using ManagerMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ManagerMS.DbContexts
{
    public interface IManagerMSContext
    {
        DbSet<CustomerExecutiveModel> AssignExecutives { get; set; }
        DbSet<Executive> Executives { get; set; }

        Task<int> SaveChanges();
    }
}