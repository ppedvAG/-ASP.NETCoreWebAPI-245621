using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data
{
    public class VehicleDbContext : DbContext
    {
        public readonly string ConnectionString;

        public DbSet<AutoMobile> Vehicles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public VehicleDbContext()
        {
#if DEBUG
            ConnectionString = @"Data Source=(localdb)\\AspNetCoreKurs;Initial Catalog=VehicleManagement;Integrated Security=True;";
#endif
        }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) 
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed.InitData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
