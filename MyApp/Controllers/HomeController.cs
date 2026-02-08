using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Controllers;

public class HomeController : Controller
{
    private const string VisitorNameCookie = "VisitorName";
    private readonly ILogger<HomeController> _logger;
    private readonly IFriendRepository _friendRepository;

    public HomeController(ILogger<HomeController> logger, IFriendRepository friendRepository)
    {
        _logger = logger;
        _friendRepository = friendRepository;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        if (!Request.Cookies.TryGetValue(VisitorNameCookie, out var visitorName) || string.IsNullOrWhiteSpace(visitorName))
        {
            return RedirectToAction(nameof(Entry));
        }

        ViewData["VisitorName"] = visitorName;
        var friends = await _friendRepository.GetAllAsync(cancellationToken);
        return View(friends);
    }

    [HttpGet]
    public IActionResult Entry()
    {
        if (Request.Cookies.TryGetValue(VisitorNameCookie, out var visitorName) && !string.IsNullOrWhiteSpace(visitorName))
        {
            return RedirectToAction(nameof(Index));
        }

        return View(new EntryViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Entry(EntryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        Response.Cookies.Append(VisitorNameCookie, model.Name.Trim(), new CookieOptions
        {
            HttpOnly = true,
            IsEssential = true,
            Expires = DateTimeOffset.UtcNow.AddHours(12)
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(VisitorNameCookie);
        return RedirectToAction(nameof(Entry));
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

public class EntryViewModel
{
    [Required(ErrorMessage = "Informe seu nome para continuar 💖")]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;
}
