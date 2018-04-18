using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaveUpSite.Models
{
    public class FakeItemRepository /*:/* IItemRepository*/
    {
        public IEnumerable<Item> Items => new List<Item>
        {
            new Item{ItemID = 1, Address = "Kazan", Description = "coollest", Name = "FairyTail", RoomCount = 10, Square = 200.0},
            new Item{ItemID = 2, Address = "Chistopol", Description = "amazing", Name = "Moon", RoomCount = 12, Square = 160.3},
            new Item{ItemID = 3, Address = "Kazan", Description = "fckin good", Name = "Sun", RoomCount = 8, Square = 180.0}
        };

    }
}
