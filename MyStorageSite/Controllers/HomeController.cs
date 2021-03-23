using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStorageSite.Models;

namespace MyStorageSite.Controllers
{
    public class HomeController : Controller
    {
        StorageContext context;

        public HomeController(StorageContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                context.Orders.Add(order);
                context.SaveChanges();
                return "OK";
            }

            return "NO";
        }

        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }

    }
}
