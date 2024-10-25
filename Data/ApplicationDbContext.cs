
using Microsoft.EntityFrameworkCore;
using OPIGESHOP.Models;

namespace OPIGESHOP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Category)
                      .HasConversion<string>();  // If using enums, ensure they are properly mapped
                entity.Property(e => e.Price)
                            .HasColumnType("decimal(18,2)");  // Specify precision and scale here


            });

            
        }
    }
}