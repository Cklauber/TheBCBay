using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBCBay.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBCBay.Controllers
{
    public class ItemController : Controller
    {
        private IItemData _itemData;
        public ItemController(IItemData itemData)
        {
            _itemData = itemData;

        }
        // GET: /<controller>/
        public IActionResult Display()
        {
            var Model = _itemData.GetAll();
            return View(Model);
        }
    }
}
