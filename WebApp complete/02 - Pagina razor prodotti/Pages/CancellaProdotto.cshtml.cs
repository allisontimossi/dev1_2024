using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class CancellaProdotto : PageModel
{
    private readonly ILogger<CancellaProdotto> _logger;

    public CancellaProdotto(ILogger<CancellaProdotto> logger)
    {
        _logger = logger;
    }

public Prodotto Prodotto { get; set; }  

    public void OnGet(int id )
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        foreach (var prodotto in prodotti)
            {
                if (prodotto.Id == id) 
                {
                    Prodotto = prodotto; 
                    break;
                }
            }
    }

//Il metodo IActionResult serve a gestire la modifica delle informazioni di un prodotto attraverso un form, 
//aggiornando il file JSON che memorizza i dati dei prodotti sul server

public IActionResult OnPost(int id)  //viene utilizzato per inviare i dati al server web
    {                                                                           //i parametri vengono passati tramite il form della pagina web
        //lettura del file JSON che si trova nella directory wwwroot e memorizzazione in una stringa
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        //deserializzazione: converte la stringa JSON in una lista di oggetti Prodotto 
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        for (int i = 0; i < prodotti.Count; i++)
        {
            if (prodotti[i].Id == id)
            {
                prodotti.RemoveAt(i);   
                break;
            }
        }

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("/Prodotti"); 
    }

}
