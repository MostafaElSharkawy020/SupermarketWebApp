using Microsoft.EntityFrameworkCore;
using SupermarketWebApp.Models;
using System.Reflection.Emit;

namespace SupermarketWebApp.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SupermarketWebApp;User Id=sa;Password=yourStrong(!)Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Card>(c => c.card)
                .WithOne(o => o.user)
                .HasForeignKey<User>(o => o.cardId);

            modelBuilder.Entity<User>()
                .HasMany<Order>(u => u.orders)
                .WithOne(o => o.user)
                .HasForeignKey(o => o.userId);


        }

    }
}



//modelBuilder.Entity<User>()
//                .HasMany(u => u.Orders)
//                .WithOne(o => o.User)
//                .HasForeignKey(o => o.UserId);
//modelBuilder.Entity<Order>()
//    .HasMany(o => o.OrderItems)
//    .WithOne(oi => oi.Order)
//    .HasForeignKey(oi => oi.OrderId);
//modelBuilder.Entity<Product>()
//    .HasMany(p => p.OrderItems)
//    .WithOne(oi => oi.Product)
//    .HasForeignKey(oi => oi.ProductId);
//modelBuilder.Entity<Category>()
//    .HasMany(c => c.Products)
//    .WithOne(p => p.Category)
//    .HasForeignKey(p => p.CategoryId);
