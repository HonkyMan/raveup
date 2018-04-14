using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaveUpSite.Models
{
    public class EFItemRepository : IItemRepository
    {
        private ApplicationDbContext context;

        public EFItemRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Item> Items => context.Items;
    }
}
