using Destinations.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Destinations.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<
        }
    }
}