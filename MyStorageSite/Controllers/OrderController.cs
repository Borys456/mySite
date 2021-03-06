using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStorageSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyStorageSite.Controllers
{
    public class OrderController : Controller
    {
        StorageContext1 context;

        public OrderController(StorageContext1 context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("AllOrders");
            
            Order ord = context.Orders.Select(o => o).Where(o => o.Id == id).First();
            //Product product = context.Products.Select(p => p).Where(p => p.Id == ord)                
            return View(ord);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditOrder(int? id)
        {
            ViewBag.Order = id;
            Order order = context.Orders.Select(o => o).Where(o => o.Id == id).First();
            return View(order);
        }
     
        [HttpPost]
        [Authorize]
        public IActionResult EditOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
            return RedirectToAction("AllOrders", "Home");
        }

    }
}
