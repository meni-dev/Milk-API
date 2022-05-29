using Microsoft.EntityFrameworkCore;
using MilkProject.DB.Entity;
using System;

namespace MilkProject.DB
{
    public class MilkDbContext : DbContext
    {
        public MilkDbContext(DbContextOptions<MilkDbContext> options):base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<DailyMilkSupply> DailyMilkSupply { get; set; }
    }
}
