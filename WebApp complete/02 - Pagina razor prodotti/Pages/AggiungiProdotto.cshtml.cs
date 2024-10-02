using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

public class AggiungiProdottoModel : PageModel
{
    Prodotto Prodotto { get; set; } 
    public List <string> Categorie { get; set; }

    [BindProperty]
    public string Codice { get; set; }  
    private readonly ILogger<AggiungiProdottoModel> _logger;

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() //viene utilizzato per ricevere i dati dal server
    {

    }

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio, int quantità, string immagine)  //viene utilizzato per inviare i dati al server web
    {     
        //i parametri vengono passati tramite il form della pagina web
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        int id = 1;
        if (prodotti.Count > 0)
        {
            id = prodotti.Count+1;
        }
        
        prodotti.Add(new Prodotto {Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Immagine = immagine});
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("Prodotti"); 
    }
}
