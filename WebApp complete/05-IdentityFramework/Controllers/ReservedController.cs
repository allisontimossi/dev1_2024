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
    public IActionResult Admin()
    {
        return View();
    }

    [Authorize(Roles = "User")]
    public IActionResult User()
    {
        return View();
    }

//voglio visualizzare la pagina Gestione solo per gli amministratori
    [Authorize(Roles = "Admin")]
    public IActionResult Gestione()
    {
        return View();
    }

//voglio visualizzare la pagina Prova solo per gli utenti
[Authorize(Roles = "User")]
    public IActionResult Prove()
    {
        return View();
    }
}