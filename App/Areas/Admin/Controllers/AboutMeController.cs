using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Areas.Admin.Controllers;
[Authorize]
[Area("Admin")]

public class AboutMeController : Controller
{
    private readonly IAboutMe about;

    public AboutMeController(IAboutMe _about)
    {
        about = _about;
    }

    public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.g = id;
        }
        return View(about.Show());
    }

    [HttpPost]
    public IActionResult Update(AboutMe_Dto dto)
    {
        var result = about.Update(dto);
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
