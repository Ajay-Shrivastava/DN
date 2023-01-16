using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using thirdapp.Models;
using BLL;
using student;

namespace thirdapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        StudentRecord sr = new StudentRecord();
        List<Student> stu =  sr.getALL();
        this.ViewData["stu"] = stu;
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
