using Application.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Items.AnyAsync() || await dbContext.Users.AnyAsync() || await dbContext.ListOfUsers.AnyAsync() || await dbContext.Orders.AnyAsync() || await dbContext.OrderDetails.AnyAsync()) return;

            var user1 = new User() { Id = Guid.NewGuid(), Name = "Ali", Surname = "Yılmaz", Email = "ali@exm.com", Gsm = "55222233344", Address = "Ankara" };
            var user2 = new User() { Id = Guid.NewGuid(), Name = "Can", Surname = "Gök", Email = "can@exm.com", Gsm = "55228833344", Address = "Istanbul" };
            var user3 = new User() { Id = Guid.NewGuid(), Name = "Cem", Surname = "Deni", Email = "cem@exm.com", Gsm = "5529999344", Address = "Izmir" };
            dbContext.AddRange(user1, user2, user3);

            var item1 = new Item() { Id = Guid.NewGuid(), Name = "Kalem", CategoryName = "Kırtasiye", Brand = "Faber", Description = "O.7 Uclu", Price = 30.00m };
            var item2 = new Item() { Id = Guid.NewGuid(), Name = "Telefon", CategoryName = "Elektronik", Brand = "Iphone", Description = "Iphone X 128Gb", Price = 15000.00m };
            var item3 = new Item() { Id = Guid.NewGuid(), Name = "Bardak", CategoryName = "Mutfak Eşyası", Brand = "Paşabahçe", Description = "12'li Su Bardağı", Price = 50.00m };
            dbContext.AddRange(item1, item2, item3);

            //var listOfUser1 = new ListOfUser() { Id = Guid.NewGuid(), ListName = "Begendiklerim", Description = "Begendigim Telefonlar", Items = { item2 }, User = user2 };
            //dbContext.AddRange(listOfUser1);


            var order1 = new Order() { Id = Guid.NewGuid(), User = user2, OrderDate = DateTimeOffset.Now, TotalPrice = item2.Price };
            dbContext.AddRange(order1);
            await dbContext.SaveChangesAsync();


        }
    }
}
