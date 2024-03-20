using Microsoft.EntityFrameworkCore;
using PropertyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMS.DbContexts
{
    public class PropertyMSContext : DbContext, IPropertyMSContext
    {
        public PropertyMSContext(DbContextOptions<PropertyMSContext> options)
                : base(options)
        {
        }

        public DbSet<Properties> Properties { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
