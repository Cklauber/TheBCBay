using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBCBay.CompositeModel;
using TheBCBay.Models;
using TheBCBay.Services;

namespace TheBCBay.Controllers
{
    public class HomeController : Controller
    {
        private IItemData _itemData;

        public HomeController(IItemData ItemData)
        {
            _itemData = ItemData;
        }




        public IActionResult Index()
        {
            var model = _itemData.GetAll();
            return View(model);
        }

        public IActionResult ViewItem(int id)
        {
            var model = _itemData.Get(id);
            if (model == null || model.Active == false)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var model = _itemData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
