using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Models;

namespace TheBCBay.Services
{
    public class InMemoryItemData : IItemData
    {
        List<ItemModel> _items;
        public InMemoryItemData()
        {
            _items = new List<ItemModel>
            {
             new ItemModel{Id = 1, Title = "Random Stuff", Description = "We are selling this random stuff", CurrentPrice = 15, TopPrice = 50, LowPrice = 10, StartDate = DateTime.Now, EndTime = DateTime.Now},
            new ItemModel{Id = 2, Title = "Another Random Stuff", Description = "We are selling this random stuff", CurrentPrice = 15, TopPrice = 50, LowPrice = 10, StartDate = DateTime.Now, EndTime = DateTime.Now},
            new ItemModel{Id = 3, Title = "Even more Random Stuff", Description = "We are selling this random stuff", CurrentPrice = 15, TopPrice = 50, LowPrice = 10, StartDate = DateTime.Now, EndTime = DateTime.Now}
            };
        }

        public IEnumerable<ItemModel> GetAll()
        {
            return _items.OrderBy(r => r.Title);
        }

        public ItemModel Get(int id)
        {
            return _items.FirstOrDefault(r=> r.Id == id);
        }

        public ItemModel Add(ItemModel newItem)
        {
            newItem.Id = _items.Max(r => r.Id) + 1;
            newItem.CurrentPrice = newItem.TopPrice;
            newItem.StartDate = DateTime.Now;
            _items.Add(newItem);
            return newItem;
        }
    }
}
