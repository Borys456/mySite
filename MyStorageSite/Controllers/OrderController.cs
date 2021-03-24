using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStorageSite.Models;

namespace MyStorageSite.Controllers
{
    public class OrderController : Controller
    {
        StorageContext context;

        public OrderController(StorageContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("AllOrders");

            ViewBag.Order = id;
            
            Order ord = context.Orders.Select(o => o).Where(o => o.Id == id).First();
            //Product product = context.Products.Select(p => p).Where(p => p == ord.Products).FirstOrDefault();
            //ord.Products = product;

            //Product product = context.Products.Select(p => p).Where(p => p.Id == ord)
                
            return View(ord);
        }

        [HttpGet]
        public IActionResult EditOrder(int? id)
        {
            ViewBag.Order = id;
            Order order = context.Orders.Select(o => o).Where(o => o.Id == id).First();
            return View();
        }


        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
            return View();
        }

    }
}
