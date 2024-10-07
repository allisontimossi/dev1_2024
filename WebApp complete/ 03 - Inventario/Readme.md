# Progetto di una pagine web con Architettura MVC (Model-View-Controller)
Applicazione che segue un'architettura separata in cui logica di business, UI e dati sono separati. 

## Controller: 
La cartella Controllers contiene le classi Controller, che gestiscono le richieste HTTP, elaborano i dati e li inviano alla View.
Ad esempio: 
```c#
public class HomeController : Controller
{
    // Il file Index.cshtml per a vista è collegato a questo controller e viene reinderizzato quando viene chiamato il metodo Index()
    public IActionResult Index() //dovrebbe restituire la pagina Index
    {
        return View();
    }

    public IActionResult Privacy() //dovrebbe restituire la pagina Privacy
    {
        return View();
    }
}
```
Di conseguenza dovremmo avere:
[ ] Una classe per Prodotti
[ ] Una classe per Aggiungi Prodotto
[ ] Una classe per Dettagli Prodotto
[ ] Una classe per Modifica Prodotto
[ ] Una classe per Elimina Prodotto

## Model
Qui vengono definiti i modelliche rappresentano i dati dell'applicazione. (Prodotto)
```c#
public class Prodotto
{
    //blablabla
}
```
## View
Sono file .cshtml, che contiene sottocartelle per ogni controller. 
Essi definiscono i layout dell'interfaccia utente tramite Razor, facendo da tramite tra il codice C# e HTML.
Di conseguenza dovremmo avere:
[ ] Un file .cshtml per Prodotti
[ ] Un  file .cshtml  per Aggiungi Prodotto
[ ] Un  file .cshtml  per Dettagli Prodotto
[ ] Una  file .cshtml  per Modifica Prodotto
[ ] Un file .cshtml  per Elimina Prodotto