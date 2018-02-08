using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBCBay.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBCBay.Controllers
{
    public class ItemController : Controller
    {
        // GET: /<controller>/
        public IActionResult Display()
        {
            var sample = new ItemModel
            {
                Id = 1,
                Title = "Random Stuff",
                Description = "We are selling this random stuff",
                CurrentPrice = 15,
                TopPrice = 50,
                LowPrice = 10,
                UsrId = 1,
                StartDate = DateTime.Now,
                EndTime = DateTime.Now
            };
            return View(sample);
        }
    }
}
