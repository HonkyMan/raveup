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

        public void SaveItem(Item item)
        {
            if (item.ItemID == 0)
            {
                context.Items.Add(item);
            }
            else
            {
                Item editedItem = context.Items.FirstOrDefault(p => p.ItemID == item.ItemID);
                if (editedItem != null)
                {
                    editedItem.Description = item.Description;
                    editedItem.Square = item.Square;
                    editedItem.RoomCount = item.RoomCount;
                    editedItem.HasBathhouse = item.HasBathhouse;
                    editedItem.HasPool = item.HasPool;
                    editedItem.Name = item.Name;
                }

            }
            context.SaveChanges();
        }

        public void CreateItem(Item item)
        {
            if (item.ItemID == 0)
            {
                context.Items.Add(item);
            }
            context.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            Item deleteditem = context.Items.FirstOrDefault(p => p.ItemID == itemId); ;
            if (deleteditem != null)
            {
                context.Remove(deleteditem);
            }
            context.SaveChanges();
        }
    }
}
