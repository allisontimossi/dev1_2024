using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

//aggiunta di pacchetto per file Json
using Newtonsoft.Json;


    public class ProdottoDettaglioModel : PageModel
    {
        private readonly ILogger<ProdottoDettaglioModel> _logger;

        public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
        {
            _logger = logger;
            logger.LogInformation("Pagina prodotto dettaglio caricata");
        }

    public Prodotto Prodotto {get; set;}   

        //riceve tutti i campi della classe Prodotto (fossero persistenti i dati basterebbe solo ID)
        
        /*
        public void OnGet(int id, string nome, decimal prezzo, string dettaglio, string immagine) 
        {
            Prodotto = new Prodotto { Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Immagine = immagine};
        }
        */

        //per passare alla view un file json
        public void OnGet(int id)
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
    }
