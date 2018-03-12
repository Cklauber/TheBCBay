using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Models;

namespace TheBCBay.Services
{
    public interface IItemData
    {
        IEnumerable<ItemModel> GetAll();
        ItemModel Get(int id);
        ItemModel Add(ItemModel newItem);
        ItemModel Update(ItemModel item);
    }
}
