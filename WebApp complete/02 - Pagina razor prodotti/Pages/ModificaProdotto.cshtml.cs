using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
//aggiungiamo lo using
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    private readonly ILogger<ModificaProdottoModel> _logger;

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }
//Aggiungiamo la proprietà
public Prodotto Prodotto { get; set; }
public string Codice { get; set; }  

public List<string> Categorie { get; set; }

//Per Modificare lavoriamo sia sul Get che sul Post
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        
        var json2 = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json2);

        foreach (var prodotto in prodotti)
            {
                if (prodotto.Id == id) 
                {
                    Prodotto = prodotto; 
                    break;
                }
            }
    }

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio, string immagine, int id, string categoria, int quantita)  //viene utilizzato per inviare i dati al server web
    {     
            
        //i parametri vengono passati tramite il form della pagina web
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        foreach (var prodotto in prodotti)
        {
            if (prodotto.Id == id)
            {
                prodotto.Nome = nome;
                prodotto.Prezzo = prezzo;
                prodotto.Dettaglio = dettaglio;
                prodotto.Immagine = immagine;
                prodotto.Categoria= categoria;
                prodotto.Quantita = quantita;
                break;
            }
        }
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToPage("/Prodotti"); 
    }
}
