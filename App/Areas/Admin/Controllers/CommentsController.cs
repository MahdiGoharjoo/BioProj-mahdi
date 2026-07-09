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
    public class CommentsController : Controller
    {
    private readonly IComments comments;

    public CommentsController(IComments _comments)
    {
        comments = _comments;
    }

    public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.msg = id;
        }
        return View(comments.ShowAdmin());
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Comments_Dto dt)
    {
        var result = comments.Add(dt);
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
        var result = comments.Delete(id);
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
        return View(comments.Find(id));
    }
    [HttpPost]
    public IActionResult Update(Comments_Dto dto)
    {
        var result = comments.Update(dto);
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
