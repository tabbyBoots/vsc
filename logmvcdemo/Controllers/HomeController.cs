using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using logmvcdemo.Models;

namespace logmvcdemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string userId = "123";
        string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        _logger.LogInformation("使用者 {UserId} 登入成功，來自 IP {IPAddress}", userId, ipAddress);
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
