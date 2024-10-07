using System.ComponentModel.DataAnnotations;
public class Prodotto //classe prodotto
{
    public int Id { get; set; } 

    public string Nome { get; set; }  //proprietà Nome
    public decimal Prezzo { get; set; } //proprietà Prezzo
    public string Dettaglio { get; set; }    //proprietà Dettaglio
    public string Immagine { get; set; }    
    public string Categoria { get; set; }   
    public int Quantita { get; set; }  
}
