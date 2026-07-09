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


public class UserController : Controller
{
    private readonly IUser user;
    public UserController(IUser _user)
    {
        user = _user;
    }

    public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.msg = id;
        }
        return View(user.ShowAdmin());
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(User_Dto dt)
    {
        var result = user.Add(dt);
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
        var result = user.Delete(id);
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
        return View(user.Find(id));
    }
    [HttpPost]
    public IActionResult Update(User_Dto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var result = user.Update(dto);
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
