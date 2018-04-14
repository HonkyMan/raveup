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
                if (!context.Items.Any())
                {
                    context.Items.AddRange(
                        new Item { Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0 },
                        new Item { Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3 },
                        new Item { Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0 }
                        );
                    context.SaveChanges();
                }
            }
                
        }
    }
}
