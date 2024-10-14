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
}