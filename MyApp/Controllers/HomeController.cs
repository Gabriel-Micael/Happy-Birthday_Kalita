using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFriendRepository _friendRepository;

    public HomeController(ILogger<HomeController> logger, IFriendRepository friendRepository)
    {
        _logger = logger;
        _friendRepository = friendRepository;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var friends = await _friendRepository.GetAllAsync(cancellationToken);
        return View(friends);
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
