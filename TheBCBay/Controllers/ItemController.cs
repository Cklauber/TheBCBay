using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBCBay.CompositeModel;
using TheBCBay.Models;
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
            var model = _itemData.GetAll();
            return View(model);
        }

        public IActionResult ViewItem(int id)
        {
            var model = _itemData.Get(id);
            if(model == null || model.Active == false)
            {
                return RedirectToAction(nameof(Display));
            }

            return View(model);
        }

        /*
         * TODO: Only get and post if it is the user who created.
         */
        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var model = _itemData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Display));
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemEditModel model)
        {
            //var model = _itemData.Get(id);
            if (ModelState.IsValid)
            {
                ItemModel updateItem = _itemData.Get(model.Id);
                updateItem.Title = model.Title;
                updateItem.Description = model.Description;
                updateItem.TopPrice = model.TopPrice;
                updateItem.LowPrice = model.LowPrice;
                updateItem.EndTime = model.EndTime;
                updateItem.Active = model.Active;
                _itemData.Update(updateItem);

                return RedirectToAction(nameof(ViewItem), new { id = model.Id });
            }
            else
            {
                return View();
            }
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ItemEditModel model)
        {
            if (ModelState.IsValid) { 
            var newItem = new ItemModel();
            newItem.Title = model.Title;
            newItem.Description = model.Description;
            newItem.TopPrice = model.TopPrice;
            newItem.LowPrice = model.LowPrice;
            newItem.EndTime = model.EndTime;
            newItem.StartDate = DateTime.Now;
            newItem.Active = true;
            _itemData.Add(newItem);

            return RedirectToAction(nameof(ViewItem), new { id = newItem.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
