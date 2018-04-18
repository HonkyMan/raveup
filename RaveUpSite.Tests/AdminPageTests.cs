using System;
using Moq;
using Xunit;
using RaveUpSite.Models;
using RaveUpSite.Controllers;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using RaveUpSite.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RaveUpSite.Tests
{
    public class AdminPageTests
    {
        [Fact]
        public void GetTest()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { ItemID = 1, Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Item { ItemID = 2, Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9, CreatedDate = DateTime.Now.AddHours(-1)  },
                    new Item { ItemID = 3,Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { ItemID = 4,Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8,  CreatedDate = DateTime.Now.AddHours(-4) },
                    new Item { ItemID = 5,Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6, CreatedDate = DateTime.Now.AddHours(-3) }
                });

            AdminController cont = new AdminController(mock.Object);
            Item[] items = (cont.Items().ViewData.Model as IEnumerable<Item>).ToArray();
            Assert.Equal(1, items[0].ItemID);
            Assert.Equal(2, items[1].ItemID);
            Assert.Equal(3, items[2].ItemID);
            Assert.Equal(4, items[3].ItemID);
            Assert.Equal(5, items[4].ItemID);
        }

        [Fact]
        public void EditTest()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { ItemID = 1, Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Item { ItemID = 2, Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9, CreatedDate = DateTime.Now.AddHours(-1)  },
                    new Item { ItemID = 3,Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { ItemID = 4,Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8,  CreatedDate = DateTime.Now.AddHours(-4) },
                    new Item { ItemID = 5,Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6, CreatedDate = DateTime.Now.AddHours(-3) }
                });

            AdminController cont = new AdminController(mock.Object);
            Item item = cont.Edit(1).ViewData.Model as Item;
            Assert.Equal(1, item.ItemID);
            
        }

        [Fact]
        public void SaveEditedTest()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { ItemID = 1, Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Item { ItemID = 2, Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9, CreatedDate = DateTime.Now.AddHours(-1)  },
                    new Item { ItemID = 3,Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { ItemID = 4,Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8,  CreatedDate = DateTime.Now.AddHours(-4) },
                    new Item { ItemID = 5,Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6, CreatedDate = DateTime.Now.AddHours(-3) }
                });
            Item item = new Item { Name = "New" };
            AdminController cont = new AdminController(mock.Object);
            IActionResult result = cont.Edit(item);
            mock.Verify(m => m.SaveItem(item));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Items", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void SaveCreatedTest()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { ItemID = 1, Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0, Rating = 5.0, CreatedDate = DateTime.Now.AddHours(-2) },
                    new Item { ItemID = 2, Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3, Rating = 4.9, CreatedDate = DateTime.Now.AddHours(-1)  },
                    new Item { ItemID = 3,Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0, Rating = 4.7 },
                    new Item { ItemID = 4,Address = "Kazan", Description = "beatiful", Name = "Ibiza", RoomCount = 16, Square = 260, Rating = 4.8,  CreatedDate = DateTime.Now.AddHours(-4) },
                    new Item { ItemID = 5,Address = "Kazan", Description = "greatest", Name = "Belgia", RoomCount = 13, Square = 100, Rating = 4.6, CreatedDate = DateTime.Now.AddHours(-3) }
                });
            Item item = new Item { Name = "New" };
            AdminController cont = new AdminController(mock.Object);
            IActionResult result = cont.Create(item);
            mock.Verify(m => m.CreateItem(item));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Items", (result as RedirectToActionResult).ActionName);
        }

    }
}