using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaveUpSite.Models.ViewModels
{
    public class MainPageModel
    {
        public List<Item> NewItems { get; set; }

        public List<Item> TopRatedItems { get; set; }
    }
}
