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
    public class ContactUsAdminController : Controller
    {
        private readonly IContactUsAdmin contactUsAdmin;

        public ContactUsAdminController(IContactUsAdmin _contactUsAdmin)
        {
            contactUsAdmin = _contactUsAdmin;
        }

        public IActionResult Index(string id)
        {
            if (id != null)
            {
                ViewBag.g = id;
            }
            return View(contactUsAdmin.Show());
        }
        [HttpPost]
        public IActionResult Update(ContactUsAdmin_Dto dto)
        {
        var result = contactUsAdmin.Update(dto);
        if (result == true)
        {
            return RedirectToAction("index", new { id = dto.Id_Dto });
        }
        else
        {
            return RedirectToAction("index", new { id = dto.Id_Dto });

        }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}