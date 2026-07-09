using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Core.InterFaces;
using App.Areas.Admin.Controllers;
using Core.DTOs;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFirst first;
    private readonly IAboutMe aboutMe;
    private readonly IStatics statics;
    private readonly IAllAboutMe allabout;
    private readonly ISerrvices serrvices;
    private readonly IComments comments;
    private readonly IBlog blog;
    private readonly IContactUsAdmin contactUsAdmin;
    private readonly IContactUsClient contactUsClient;
    
    public HomeController(ILogger<HomeController> logger , IFirst _first , IAboutMe _aboutMe , IStatics _statics ,
     IAllAboutMe _allabout ,ISerrvices _serrvices ,IComments _comments , IBlog _blog ,
      IContactUsAdmin _contactUsAdmin , IContactUsClient _contactUsClient)
    {
        _logger = logger;
        first = _first;
        aboutMe = _aboutMe;
        statics = _statics;
        allabout = _allabout;
        serrvices = _serrvices;
        comments = _comments;
        blog = _blog;
        contactUsAdmin = _contactUsAdmin;
        contactUsClient = _contactUsClient;
    }

    public IActionResult Index()
    {
        ViewBag.First = first.Show();
        ViewBag.AboutMe = aboutMe.Show();
        ViewBag.Statics = statics.ShowClient();
        ViewBag.AllAboutMe = allabout.ShowClient();
        ViewBag.Serrvices = serrvices.ShowClient();
        ViewBag.Comments = comments.ShowClient();
        ViewBag.Blog = blog.ShowClient();
        ViewBag.ContactUsAdmin = contactUsAdmin.Show();
        ViewBag.ContactUsClient = contactUsClient.Show();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(ContactUsClient_Dto dt)
    {
        var result = contactUsClient.Add(dt);
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
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
