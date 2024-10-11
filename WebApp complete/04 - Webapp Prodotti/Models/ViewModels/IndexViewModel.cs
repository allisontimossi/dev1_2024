public class IndexViewModel
{
    //quello che esce dal file json è una List che contiene il tipo oggetto denominato Prodotto
    public IEnumerable<Prodotto> Prodotti { get; set; }
    
    public decimal? MinPrezzo { get; set; }
    public decimal? MaxPrezzo { get; set; }
    public int? NumeroPagine { get; set; }  
}