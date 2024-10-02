using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

//aggiunta di pacchetto per file Json
using Newtonsoft.Json;

    public class ProdottiModel : PageModel
    {
        private readonly ILogger<ProdottiModel> _logger;

        public ProdottiModel(ILogger<ProdottiModel> logger)
        {
            //fa comparire nel terminale un messaggio di avvenuto caricamento 
            _logger = logger;
            logger.LogInformation("Prodotti caricati");
        }
        public IEnumerable<Prodotto> Prodotti { get; set; } 
        public int numeroPagine { get; set; }
        //public void OnGet() //richiamo dei contenuti
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex) //aggiunta di argomenti per filtrare i prodotti per prezzo  
        {
            /*
            // i dati dei prodotti andranno presi da un Json o Database. 
            //per questa esercitazione va bene messo così:
            var allProdotti = new List <Prodotto> //creazione Lista prodotti
            {
                //popolazione della lista
                new Prodotto {Immagine = "img/img1.jpg", Id = 1, Nome = "Prodotto 1", Prezzo = 100},
                new Prodotto {Immagine = "img/img2.jpg", Id = 2,  Nome = "Prodotto 2", Prezzo = 200},
                new Prodotto {Immagine = "img/img3.jpg", Id = 3,  Nome = "Prodotto 3", Prezzo = 300},
                new Prodotto {Immagine = "img/img1.jpg", Id = 4, Nome = "Prodotto 1", Prezzo = 150},
                new Prodotto {Immagine = "img/img2.jpg", Id = 5,  Nome = "Prodotto 2", Prezzo = 250},
                new Prodotto {Immagine = "img/img3.jpg", Id = 6,  Nome = "Prodotto 3", Prezzo = 350},
                new Prodotto {Immagine = "img/img1.jpg", Id = 7, Nome = "Prodotto 1", Prezzo = 400},
                new Prodotto {Immagine = "img/img2.jpg", Id = 8,  Nome = "Prodotto 2", Prezzo = 500},
                new Prodotto {Immagine = "img/img3.jpg", Id = 9,  Nome = "Prodotto 3", Prezzo = 600},
                new Prodotto {Immagine = "img/img1.jpg", Id = 10, Nome = "Prodotto 1", Prezzo = 550},
                new Prodotto {Immagine = "img/img2.jpg", Id = 11,  Nome = "Prodotto 2", Prezzo = 650},
                new Prodotto {Immagine = "img/img1.jpg", Id = 12, Nome = "Prodotto 1", Prezzo = 120},
                new Prodotto {Immagine = "img/img3.jpg", Id = 13,  Nome = "Prodotto 3", Prezzo = 750},
                new Prodotto {Immagine = "img/img2.jpg", Id = 14,  Nome = "Prodotto 2", Prezzo = 220},
                new Prodotto {Immagine = "img/img3.jpg", Id = 15,  Nome = "Prodotto 3", Prezzo = 1000}
            };
            */

            //per passare alla view la lista del file Json
                var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
                var allProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

            
                //creazione di una lista per prodotti filtrati
                var prodottiFiltrati = new List<Prodotto>();

                foreach (var prodotto in allProdotti)
                {
                    bool aggiungi = true;

                    if (minPrezzo.HasValue)
                    {
                        if (prodotto.Prezzo < minPrezzo.Value)
                        {
                            aggiungi = false;
                        }
                    }

                    if (maxPrezzo.HasValue)
                    {

                        if (prodotto.Prezzo > maxPrezzo.Value)
                        {
                            aggiungi = false;
                        }
                    }
                    if (aggiungi)
                    {
                        prodottiFiltrati.Add(prodotto);
                    }
                }
        Prodotti = prodottiFiltrati;
        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);
            //Math.Ceiling arrotonda il numero di pagine all'intero più vicino
            //Prodotti.Count() restituisce il numero di prodotti
            // 6.0 è il numero di prodotti per pagina

        Prodotti = Prodotti.Skip(((pageIndex ?? 1)-1)*6).Take(6);
        } 
        }
    