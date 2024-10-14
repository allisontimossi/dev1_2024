using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.AddToRoleAsync(user, "Admin");
        return RedirectToAction ("Index", "Home");
    }

//trova l'utente, trova i ruoli e stampa il ruolo dell'itente
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.GetRolesAsync(user);
        return Content (string.Join(","));
    }

    public async Task<IActionResult> RemoveFromRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        return RedirectToAction ("Index", "Home");
    }

    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.AddToRoleAsync(user, "User");
        return RedirectToAction ("Index", "Home");
    }

    public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.RemoveFromRoleAsync(user, "User");
        return RedirectToAction ("Index", "Home");
    }
}