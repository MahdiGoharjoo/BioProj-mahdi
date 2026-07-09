using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.DTOs;
using Data.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly Application db;

        public LoginController(ILogger<LoginController> logger, Application _db)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Login()
        {
            // TODO: Your code here
            return View();
        }
        public IActionResult Check(User_Dto dt)
        {
            var find = db.tbl_Users.SingleOrDefault(p => p.UserName == dt.UserName_Dto && p.Password == dt.Password_Dto);
            if (find == null)
            {
                return RedirectToAction("Login");
            }
            var claims = new List<Claim>()
        {
        new Claim (ClaimTypes.NameIdentifier, find.Id.ToString ()),
        new Claim (ClaimTypes.Name, find.FullName),
        };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(principal, properties);
            return RedirectToAction("index", "Home" , new{Area="Admin"});
        }
         public IActionResult exit()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }
            
        
        
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}