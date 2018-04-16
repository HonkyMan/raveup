using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RaveUpSite.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public double Square { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
        public bool HasPool { get; set; } = false;
        public bool HasBathhouse { get; set; } = false;
        public int FloorsCount { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Rating { get; set; }
    }
}
