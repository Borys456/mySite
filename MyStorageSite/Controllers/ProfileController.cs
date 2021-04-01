using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStorageSite.Models;

namespace MyStorageSite.Controllers
{
    public class ProfileController : Controller
    {
        StorageContext1 context;

        public ProfileController(StorageContext1 storage)
        {
            this.context = storage;
        }

        [HttpGet]
        public IActionResult ProfileUser()
        {

            User user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public IActionResult ProfileUser(User user)
        {
            //User user = context.Users.FirstOrDefault(u => u.Email == email);
            return View(user);
        }

    }
}
