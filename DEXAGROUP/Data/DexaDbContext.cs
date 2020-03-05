using DEXAGROUP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEXAGROUP.Data
{
    public class DexaDbContext : IdentityDbContext<AppUser>
    {
        public DexaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Outlets> Outlets { get; set; }

    }
}
