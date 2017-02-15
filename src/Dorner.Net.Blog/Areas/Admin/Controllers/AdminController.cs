using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dorner.Net.Blog.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        public AdminController()
        {
            // do stuff
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{page:int?}")]
        public IActionResult Orders()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Shop()
        {
            return View();
        }

        [Route("[action]/newest")]
        public IActionResult Payments()
        {
            return View();
        }
    }
}
