using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStorageSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MyStorageSite.Controllers
{
    public class AcountController : Controller
    {
        StorageContext1 context;

        public AcountController(StorageContext1 context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    context.Users.Add(new User { Email = model.Email, Address = model.Address, Name = model.Name, Phone = model.Phone, Password = model.Password });
                    context.SaveChanges();
                    return RedirectToAction("Login", "Acount");
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Auth(model.Email);
                    return RedirectToAction("_ViewStart", "MainPage");
                }

            }
            return View();
        }
        
        private void Auth(string userName)
        {
            var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, userName) };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicatinCokie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        //[HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acount");
        }

    }
}
