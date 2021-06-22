using Microsoft.EntityFrameworkCore;

using Andreys.Data.Models;

namespace Andreys.Data
{

    public class AndreysDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Product> Products { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Andreys;Integrated Security=true;");
            }
        }
    }
}
