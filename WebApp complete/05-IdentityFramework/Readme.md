dotnet aspnet-codegenerator identity -dc MvcAuthApp.Data.ApplicationDbContext --files "Account.Register"

## Webapp Identity Framework

ASP.NET Identity è un framework sviluppato per la gestione e autorizzazione nelle applicazioni ASP.NET, utilizzato per creare sistemi di autenticazione come login, registrazione, gestione dei ruoli e delle autorizzazioni. 

## 1- Creare un amministratore di default
```c#
async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)

{//rende disponibile i ruoli
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    } 

    //rende disponibile gli utenti
    if (await userManager.FindByEmailAsync("info@admin.com")== null)
    {
        var user = new IdentityUser{
            UserName = "info@admin.com",
            Email = "info@admin.com",
        };

    var result = await userManager.CreateAsync(user, "Admin123!");
    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(user, ("Admin"));
    }
    }
}

//configuriamo un altro using
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);
}  

```

## 2- Aggiungere gestione ruoli Program.cs



```c#
//in 
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//aggiungere
    .AddRoles<IdentityRole>()

//poi aggiungere 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }
}

//infine aggiungere la classe

public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        //definiamo i ruoli e li creiamo se già non esistono
        var roles = new List <string> { "Admin", "User"};  
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }}}
```

### Riservare pagina a utente specifico

In ReservedController.cs
```c#
[Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }
```
Aggiungere la view con lo stesso nome del metodo e compilare la view 

@{
    ViewData["Title"] = "Pagina riservata agli amministratori";
}
<h3> Pagina riservata </h3>
<p> QUesta pagina è accessibile solo agli utenti autenticati </p>

Aggiungere a Layout un'altra view, dando il collegamento:
```c#
@if (User.Identity.IsAuthenticated)
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Reserved" asp-action="Index">Bottone solo se sei registrato</a>
        </li>
    }
```

Far vedere determinate funzionalità solo ad un utente oppure un'altro:
```c#


```



