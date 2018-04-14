using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaveUpSite.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Square { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
    }
}
