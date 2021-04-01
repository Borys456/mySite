using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyStorageSite.Data;

namespace MyStorageSite.Controllers
{
    public class AdminController : Controller
    {
        UserManager<IdentityUser> userManager;
        UserContext context;

        public AdminController(UserContext context)
        {
            this.context = context;
        }

        public IActionResult AllUsers()
        {
            return View(context.Users.ToList());
        }
    }
}
