using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


public class ProdottiController: Controller
{
    public IEnumerable<Prodotto> Prodotti { get; set; }
    public List<string> Categorie { get; set; }
    public string Codice { get; set; }
    private readonly string prodottiFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json/prodotti.json");
    //carica i prodotti dal file json
    public IEnumerable<Prodotto> CaricaProdotti()
    {
        if (System.IO.File.Exists(prodottiFilePath))
        {
            var json = System.IO.File.ReadAllText(prodottiFilePath);
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            return prodotti; //va messo un ritorno esplicito dei dati 
        
        }
        else
        {
            return new List<Prodotto>();   
        }
    }

    public void Salva()
    {
        System.IO.File.WriteAllText(prodottiFilePath, JsonConvert.SerializeObject(prodotti, Formatting.Indented));
        return RedirectToAction("Index");
    }

    //GET /Prodotti
    //Errore foreach (var prodotti in Model): non funzionava perché non avevo messo il get
    public IActionResult Index ()
    {
        var prodottiTotali = CaricaProdotti();
        return View(prodottiTotali);   
    }
    
    //GET-POST /Prodotti/AggiungiProdotto
    public IActionResult AggiungiProdotto ()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AggiungiProdotto (Prodotto prodotto)
    {
        //Deserializzare i prodotti esistenti dalla lista prodotto
        var prodotti = CaricaProdotti().ToList();
        //generazione dell'ID
        int id = 1;
        if (prodotti.Count > 0)
        {
            id = prodotti[prodotti.Count - 1].Id + 1;
        }
        prodotto.Id = id;
        //generazione dell'immagine se non inserita
        if (prodotto.Immagine == null)
        {
            prodotto.Immagine = "img/default.jpg";
        }
        prodotti.Add(prodotto);

        Salva();
    }

    public IActionResult ModificaProdotto (int id)
    {
        return View();
    }
    [HttpPost]
    public IActionResult ModificaProdotto ()
    {
        var prodotti = CaricaProdotti().ToList();

}