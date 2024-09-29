using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data.Concrete
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCategory>();

            modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();

            modelBuilder.Entity<Product>().HasData(
                new List<Product>(){
                    new() { Id=1, Name="IPhone 12", Price=36000, Description="IPhone 12 Description"},
                    new() { Id=2, Name="IPhone 13", Price=46000, Description="IPhone 13 Description"},
                    new() { Id=3, Name="IPhone 14", Price=56000, Description="IPhone 14 Description"},
                    new() { Id=4, Name="IPhone 15", Price=66000, Description="IPhone 15 Description"},
                    new() { Id=5, Name="IPhone 16", Price=76000, Description="IPhone 16 Description"},
                    new() { Id=6, Name="IPhone 17", Price=86000, Description="IPhone 17 Description"},
                    new() { Id=7, Name="AirPods 2. Nesil", Price=5600, Description="AirPods 2. Nesil Description"},
                    new() { Id=8, Name="AirPods 3. Nesil", Price=6300, Description="AirPods 3. Nesil Description"},
                    new() { Id=9, Name="AirPods Pro 2", Price=12000, Description="AirPods Pro 2 Description"},
                    new() { Id=10, Name="AirPods Max", Price=27000, Description="AirPods Max Description"},
                    new() { Id=11, Name="MacBook Pro", Price=75000, Description="MacBook Pro Description"},
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new List<Category>(){
                new() { Id = 1, Name = "Telefon", Url = "telefon" },
                new() { Id = 2, Name = "Kulaklık", Url = "kulaklık" },
                new() { Id = 3, Name = "Laptop", Url = "laptop" },
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new List<ProductCategory>(){
                    new ProductCategory(){ProductId=1,CategoryId=1},
                    new ProductCategory(){ProductId=2,CategoryId=1},
                    new ProductCategory(){ProductId=3,CategoryId=1},
                    new ProductCategory(){ProductId=4,CategoryId=1},
                    new ProductCategory(){ProductId=5,CategoryId=1},
                    new ProductCategory(){ProductId=6,CategoryId=1},
                    new ProductCategory(){ProductId=7,CategoryId=2},
                    new ProductCategory(){ProductId=8,CategoryId=2},
                    new ProductCategory(){ProductId=9,CategoryId=2},
                    new ProductCategory(){ProductId=10,CategoryId=2},
                    new ProductCategory(){ProductId=11,CategoryId=3},
                }
            );
        }
    }

    
}