using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

public class ProdottiController : Controller
{
    private readonly ILogger<ProdottiController> _logger;
    public ProdottiController(ILogger<ProdottiController> logger)
    {
        _logger = logger;
    }

    private readonly string _prodottiFilePath = "wwwroot/json/prodotti.json";
    //private readonly string _categorieFilePath = "wwwroot/json/categorie.json";   

    private List <Prodotto> CaricaProdotti()
    {
        try
        {
            var json = System.IO.File.ReadAllText(_prodottiFilePath);
            _logger.LogInformation("Prodotti json caricati" + json);
            return JsonConvert.DeserializeObject<List<Prodotto>>(json) ?? new List<Prodotto>();
        }
        catch(Exception eccezione)
        {
            _logger.LogError("Errore nella lettura: {Message} \n Exception Type: {Exception Type} \n Stack Trace : {StackTrace}", eccezione.Message , eccezione.GetType().Name , eccezione.StackTrace);
            return new List<Prodotto>();
        }
    }

    public IActionResult Index(int? minPrezzo, int? maxPrezzo, int indicePagina = 1)
    {
        var listaProdotti = CaricaProdotti();

        if (minPrezzo.HasValue)
        {
            //prodotti.Where(...) applica un filtro sulla collezione prodotti 
            // La funzione Where restituisce solo gli elementi che soddisfano la condizione specificata
            //Se la condizione è specificata, allora restituisce solo gli elementi in cui prezzo > filtro
            listaProdotti = listaProdotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
        }
        if (maxPrezzo.HasValue)
        {
            listaProdotti = listaProdotti.Where(p=> p.Prezzo <= maxPrezzo.Value).ToList();
        }

        int prodottiPerPagina = 6;
        //chiedere a Fra
        var prodottiImpaginati = listaProdotti.Skip((indicePagina - 1) * prodottiPerPagina).Take(prodottiPerPagina);

        var viewModel = new IndexViewModel
        {
            Prodotti = prodottiImpaginati,
            // ?? se minPrezzo non ha un valore, gli diamo 0
            MinPrezzo = minPrezzo ?? 0,
            // ?? se maxPrezzo non ha un valore, gli diamo il valore più alto tra i prezzi dei prodotti
            MaxPrezzo = maxPrezzo ?? listaProdotti.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)listaProdotti.Count() / prodottiPerPagina)
        };
        return View (viewModel);
    }
}