using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace _05_IdentityFramework.Controllers;
public class ReservedController : Controller
{
    [Authorize] //tag helper 
    public IActionResult Index()
    {
        return View();
    }

    //limitare la view ad un tipo di utente:
    [Authorize(Roles = "Admin")]
    public IActionResult AggiungiProdotto()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public IActionResult ModificaProdotto()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public IActionResult CancellaProdotto()
    {
        return View();
    }

    [Authorize(Roles = "User")]
    public IActionResult User()
    {
        return View();
    }
}