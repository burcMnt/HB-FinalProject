using Application.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Application.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ListOfUser> ListOfUsers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new Item() { Id = Guid.NewGuid(), Name = "Kalem", CategoryName = "Kırtasiye", Brand = "Faber", Description = "O.7 Uclu", Price = 30.00m, Quantity = 3,DiscountedPrice=25.00m });
            // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }
}
