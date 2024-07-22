using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 100,
                    Name = "Toy",
                    Description = "ElephantToy",
                    Price = 500,
                    imageURL = "https://subhastorageacc07.blob.core.windows.net/toy1/image1.jpeg"
                },
                new Product()
                {
                    Id = 101,
                    Name = "Toy",
                    Description = "Dolphin Toy",
                    Price = 650,
                    imageURL = "https://subhastorageacc07.blob.core.windows.net/toy1/image2.jpg"
                }
            );

            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasColumnType("decimal(18, 2)");
        }
    }
}
