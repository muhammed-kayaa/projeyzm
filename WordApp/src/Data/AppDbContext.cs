using Microsoft.EntityFrameworkCore;
using WordApp.Models;

namespace WordApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=WordApp;Trusted_Connection=True;",
                sqlOptions => sqlOptions.EnableRetryOnFailure()
            );
        }
    }
}