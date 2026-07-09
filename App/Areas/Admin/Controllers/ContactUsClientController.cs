using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace App.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ContactUsClientController : Controller
    {
        private readonly IContactUsClient contactusclient;

        public ContactUsClientController(IContactUsClient _contactusclient)
        {
            contactusclient = _contactusclient;
        }

        public IActionResult Index(long id)
        {
            if (id != null)
            {
                ViewBag.msg = id;
            }
            return View(contactusclient.Show());
        }
        public IActionResult Delete(long id)
        {
            var result = contactusclient.Delete(id);
            if (result == true)
            {
                return RedirectToAction("index", new { id = "عملیات با موفقیت انجام شد" });
            }
            else
            {
                return RedirectToAction("index", new { id = "عملیات ناموفق" });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}