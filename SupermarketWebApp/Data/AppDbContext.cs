using Microsoft.EntityFrameworkCore;
using SupermarketWebApp.Models;
using System.Reflection.Emit;

namespace SupermarketWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SupermarketSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
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

            modelBuilder.Entity<Category>()
                .HasMany<Product>(o => o.products)
                .WithOne(oi => oi.category)
                .HasForeignKey(oi => oi.categoryId);
           
            modelBuilder.Entity<OrderItem>().HasKey(sc => new { sc.orderId, sc.productId });

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.orderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(oi => oi.product)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.productId);

            modelBuilder.Entity<Product>()
                .HasData(new List<Product>
                {
                    new Product { id = 1, name = "Apple", description = "Fresh red apples", price = 0.5m, imagePath = "images/apple.jpg", quantity = 100, categoryId = 1 },
                    new Product { id = 2, name = "Banana", description = "Ripe bananas", price = 0.3m, imagePath = "images/banana.jpg", quantity = 150, categoryId = 1 },
                    new Product { id = 3, name = "Carrot", description = "Organic carrots", price = 0.4m, imagePath = "images/carrot.jpg", quantity = 200, categoryId = 2 }
                });

            modelBuilder.Entity<Category>()
                .HasData
                (new List<Category>
                {
                    new Category { id = 1, name = "Fruits" ,description="dzdbzxfxbd",imagePath="dgafddsfs"},
                    new Category { id = 2, name = "Vegetables",description = "dzdbzxfxbd",imagePath = "dgafddsfs" }
                });
        }

    }
}

//modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.SId, sc.CId });

//modelBuilder.Entity<StudentCourse>()
//.HasOne<Student>(sc => sc.Student)
//.WithMany(s => s.StudentCourses)
//.HasForeignKey(sc => sc.SId);


//modelBuilder.Entity<StudentCourse>()
//.HasOne<Course>(sc => sc.Course)
//.WithMany(s => s.StudentCourses)
//.HasForeignKey(sc => sc.CId);



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
