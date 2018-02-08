using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Models;

namespace TheBCBay.Services
{
    interface IItemData
    {
        public IEnumerable<ItemModel> GetAll();
        ItemModel Get(int id);
    }
}
