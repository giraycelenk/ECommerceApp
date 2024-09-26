using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data.Concrete
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>(){
                    new() { Id=1, Name="IPhone 12", Price=36000, Description="IPhone 12 Description", Category="Telefon" },
                    new() { Id=2, Name="IPhone 13", Price=46000, Description="IPhone 13 Description", Category="Telefon" },
                    new() { Id=3, Name="IPhone 14", Price=56000, Description="IPhone 14 Description", Category="Telefon" },
                    new() { Id=4, Name="IPhone 15", Price=66000, Description="IPhone 15 Description", Category="Telefon" },
                    new() { Id=5, Name="IPhone 16", Price=76000, Description="IPhone 16 Description", Category="Telefon" },
                    new() { Id=6, Name="IPhone 17", Price=86000, Description="IPhone 17 Description", Category="Telefon" },
                    new() { Id=7, Name="AirPods 2. Nesil", Price=5600, Description="AirPods 2. Nesil Description", Category="Kulaklık" },
                    new() { Id=8, Name="AirPods 3. Nesil", Price=6300, Description="AirPods 3. Nesil Description", Category="Kulaklık" },
                    new() { Id=9, Name="AirPods Pro 2", Price=12000, Description="AirPods Pro 2 Description", Category="Kulaklık" },
                    new() { Id=10, Name="AirPods Max", Price=27000, Description="AirPods Max Description", Category="Kulaklık" },
                }
            );
        }
    }

    
}