using System;
using Moq;
using Xunit;
using RaveUpSite.Models;
using RaveUpSite.Controllers;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using RaveUpSite.Models.ViewModels;
namespace RaveUpSite.Tests
{
    public class MainPageTests
    {
        [Fact]
        public void MainTest()
        {
            
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Item { Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9, CreatedDate = DateTime.Now.AddHours(-1)  },
                    new Item { Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8,  CreatedDate = DateTime.Now.AddHours(-4) },
                    new Item { Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6, CreatedDate = DateTime.Now.AddHours(-3) }
                });
            MainController controller = new MainController(mock.Object, null);
            controller.NewItemCount = 4;
            controller.RatedItemCount = 4;
            MainPageModel result = controller.Main().ViewData.Model as MainPageModel;
            Assert.Equal("Sun", result.NewItems.First().Name);
            Assert.Equal(4, result.NewItems.Count);
            Assert.Equal("FairyTail", result.TopRatedItems.First().Name);
            Assert.Equal(4, result.TopRatedItems.Count);

        }
        
    }
}
