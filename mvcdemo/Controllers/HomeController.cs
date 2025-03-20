using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcdemo.Models;
using mvcdemo.Filters;
namespace mvcdemo.Controllers;

[TypeFilter(typeof(AuthorizationFilter))]

[AuthorizationFilter]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [TypeFilter(typeof(ActionFilter))]

    [AuthorizationFilter]
    public IActionResult Index()
    {
        return View();
    }

    [TypeFilter(typeof(ActionFilter))]

    [AuthorizationFilter]
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
