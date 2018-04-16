using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace RaveUpSite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                IEnumerable<Item> items = new List<Item>
                {
                    new Item { Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0 },
                    new Item { Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9 },
                    new Item { Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8},
                    new Item { Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6}
                };
                if (!context.Items.Any())
                {
                    context.Items.AddRange(items);
                    context.SaveChanges();
                }
            }
                
        }
    }
}
