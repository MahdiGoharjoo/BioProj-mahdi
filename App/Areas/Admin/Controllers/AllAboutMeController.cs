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

public class AllAboutMeController : Controller
{
    private readonly IAllAboutMe allabout;

    public AllAboutMeController(IAllAboutMe _allabout)
    {
        allabout = _allabout;
    }

    public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.msg = id;
        }
        return View(allabout.ShowAdmin());
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(AllAboutMe_Dto dt)
    {
        var result = allabout.Add(dt);
        if (result == true)
        {
            return RedirectToAction("index", new { id = "عملیات با موفقیت انجام شد" });
        }
        else
        {
            return RedirectToAction("index", new { id = "عملیات ناموفق" });
        }
    }
    public IActionResult Delete(long id)
    {
        var result = allabout.Delete(id);
        if (result == true)
        {
            return RedirectToAction("index", new { id = "عملیات با موفقیت انجام شد" });
        }
        else
        {
            return RedirectToAction("index", new { id = "عملیات ناموفق" });
        }
    }
    [HttpGet]
    public IActionResult Update(long id)
    {
        return View(allabout.Find(id));
    }
    [HttpPost]
    public IActionResult Update(AllAboutMe_Dto dto)
    {
        var result = allabout.Update(dto);
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
