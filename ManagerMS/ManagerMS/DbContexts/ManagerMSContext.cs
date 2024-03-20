using ManagerMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMS.DbContexts
{
    public class ManagerMSContext : DbContext, IManagerMSContext
    {
        public ManagerMSContext(DbContextOptions<ManagerMSContext> options)
                : base(options)
        {
        }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<CustomerExecutiveModel> AssignExecutives { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
