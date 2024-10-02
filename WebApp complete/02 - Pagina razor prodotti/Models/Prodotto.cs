using System.ComponentModel.DataAnnotations;
public class Prodotto //classe prodotto
{
    public int Id { get; set; } 
    [Required]
    public string Nome { get; set; }  //proprietà Nome
    public decimal Prezzo { get; set; } //proprietà Prezzo
    [StringLength(50, MinimumLength = 3, ErrorMessage="Il Nome deve essere compreso tra 3 e 50 caratteri.")]
    public string Dettaglio { get; set; }    //proprietà Dettaglio
    public string Immagine { get; set; }    
    public string Categoria { get; set; }   
    public int Quantità { get; set; }  
}
