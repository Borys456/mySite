﻿using System;
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
            Product product = context.Products.Select(p => p).Where(p => p.Id == ord.Products.Id).FirstOrDefault();
            ord.Products = product;

            return View(ord);
        }
    }
}