using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace LabBusinessModel.Data
{
    public class MovieDbContext : DbContext
    {
        private readonly string ConnectionString;

        public MovieDbContext()
        {
#if DEBUG
            ConnectionString = @"Data Source=(localdb)\\AspNetCoreKurs;Initial Catalog=MovieStoreDb;Integrated Security=True;";
#endif
        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new List<Movie>
            {
                new Movie()
                {
                    Id = 1,
                    Title = "Coda",
                    Description = "Film über talentierten Musikerin",
                    Price = 19.99m,
                    Genre = MovieType.Drama
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Kind Richard",
                    Description = "Film über Serena und Venus Williams",
                    Price = 19.99m,
                    Genre = MovieType.Docu
                }
            });
        }
    }
}
