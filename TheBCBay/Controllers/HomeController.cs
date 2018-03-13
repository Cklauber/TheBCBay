using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
