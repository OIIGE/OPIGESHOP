
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

        public DbSet<Product> Products { get; set; }

        public DbSet<AppUsers> AppUsers { get; set; }
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

            modelBuilder.Entity<AppUsers>(entity =>
            {
                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.AddressId)
                      .IsRequired();

            });
        }
    }
}