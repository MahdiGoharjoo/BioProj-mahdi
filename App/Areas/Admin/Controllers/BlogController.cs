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

namespace App.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BlogController : Controller
    {
    private readonly IBlog blog;

    public BlogController(IBlog _blog)
    {
        blog = _blog;
    }
public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.msg = id;
        }
        return View(blog.ShowAdmin());
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Blog_Dto dt)
    {
        var result = blog.Add(dt);
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
        var result = blog.Delete(id);
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
        return View(blog.Find(id));
    }
    [HttpPost]
    public IActionResult Update(Blog_Dto dto)
    {
        var result = blog.Update(dto);
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