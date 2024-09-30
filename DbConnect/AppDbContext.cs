using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DbConnect
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Production> Productions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Production>()
                .HasOne(pr => pr.Employee)
                .WithMany()
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Production>()
                .HasOne<Product>(pr => pr.Product)
                .WithMany()
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
