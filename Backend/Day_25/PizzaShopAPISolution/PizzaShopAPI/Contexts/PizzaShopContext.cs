﻿
using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Contexts
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza()
                {
                    Id = 1,
                    Name = "GensPark Special Pizza",
                    Price = 100,
                    ImageUrl = "",
                    Description = "A classic pizza with mozzarella cheese, and basil.",
                    InStock = false,
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Chicken Pizza",
                    Price = 200,
                    ImageUrl = "",
                    Description = "A spicy pizza with fried chicken, and chillies.",
                    InStock = true,
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Veg Paneer Pizza",
                    Price = 150,
                    ImageUrl = "",
                    Description = "A spicy pizza with Vegetables, and paneer.",
                    InStock = true,
                }
                );
           
               
                
        }
    }
}
