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

public class FirstController : Controller
{
    private readonly IFirst first;

    public FirstController(IFirst _first)
    {
        first = _first;
    }

    public IActionResult Index(string id)
    {
        if (id != null)
        {
            ViewBag.g = id;
        }
        return View(first.Show());
    }

    [HttpPost]
    public IActionResult Update(First_Dto dto)
    {
        var result = first.Update(dto);
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
