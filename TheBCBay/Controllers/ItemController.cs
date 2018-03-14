using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

  
        //On both edit we are going to make sure the item belongs to the user
        [HttpGet,Authorize]
        public IActionResult EditItem(int id)
        {
            var model = _itemData.Get(id);
            string _user = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            if (model == null || _user != model.Owner)
            {
                return RedirectToAction(nameof(Display));
            }
            return View(model);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemEditModel model)
        {
            ItemModel updateItem = _itemData.Get(model.Id);
            string _user = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            if (ModelState.IsValid && _user == updateItem.Owner)
            {

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

        [HttpGet, Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult Create(ItemEditModel model)
        {
            if (ModelState.IsValid) {
            string _user = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            var newItem = new ItemModel();
            newItem.Title = model.Title;
            newItem.Description = model.Description;
            newItem.TopPrice = model.TopPrice;
            newItem.LowPrice = model.LowPrice;
            newItem.EndTime = model.EndTime;
            newItem.StartDate = DateTime.Now;
            newItem.Active = true;
            newItem.Owner = _user;
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
