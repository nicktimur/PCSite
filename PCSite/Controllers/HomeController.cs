using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PCSite.Models;

namespace PCSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SatisdbContext _db;

    public HomeController(ILogger<HomeController> logger, SatisdbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [SendUserInfo]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
