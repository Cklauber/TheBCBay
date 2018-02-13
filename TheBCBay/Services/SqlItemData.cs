using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Data;
using TheBCBay.Models;

namespace TheBCBay.Services
{
    public class SqlItemData : IItemData
    {
        private TheBCBayDBContext _context;
        public SqlItemData(TheBCBayDBContext context)
        {
            _context = context;
        }

        public ItemModel Add(ItemModel newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public ItemModel Get(int id)
        {
            return _context.Items.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ItemModel> GetAll()
        {
            return _context.Items.OrderBy(r => r.Title);
        }
    }
}
