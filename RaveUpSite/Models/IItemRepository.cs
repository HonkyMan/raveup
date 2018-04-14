using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaveUpSite.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> Items { get; }
    }
}
