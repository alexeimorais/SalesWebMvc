using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext()
        {

        }
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
            SeedingService seedingService = new SeedingService(this);
            seedingService.Seed();
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Sellers { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecords { get; set; }


    }
}
