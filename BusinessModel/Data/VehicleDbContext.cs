using BusinessModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data
{
    // Statt DbContext verwenden wir jetzt den IdentityDbContext welcher Benutzer und Rollen enthaelt.
    public class VehicleDbContext : IdentityDbContext
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
            base.OnModelCreating(modelBuilder);

            new Seed()
                .InitData(modelBuilder)
                .InitIdentityData(modelBuilder);
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
