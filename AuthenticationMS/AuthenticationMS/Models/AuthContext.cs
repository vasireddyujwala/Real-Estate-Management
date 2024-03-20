using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationMS.Models
{
    public class AuthContext:DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
