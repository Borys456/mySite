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
        //int? pr_id = null;
        public HomeController(StorageContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            //pr_id = id;
            if (id == null)
                return RedirectToAction("AllProducts");
            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (ModelState.IsValid)
            {
                Order order1 = new Order();
                //order1.User = order.User;
                order1.Address = order.Address;
                order1.contactPhone = order.contactPhone;
                order1.OrderDate = DateTime.Now;
                order1.Products = context.Products.Select(p => p).Where(p => p.Id == order.Products.Id).First();
                
                context.Orders.Add(order1);
                context.SaveChanges();
                return View();
            }

            return View();
        }

        public IActionResult AllOrders()
        {
            return View(context.Orders.ToList());
        }

        public IActionResult AllProducts()
        {
            return View(context.Products.ToList());
        }

    }
}
