using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyStorageSite.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult _ViewStart()
        {
            return View();
        }
    }
}
