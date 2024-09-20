class Persona
{
    public string nome;
    public string cognome;
    public int eta;
    public Persona (string nome, string cognome, int eta) //queto passaggio serve per inizializzare i campi dell'oggetto con valori specifici altrimenti i campi non vengono inizializzati
    {
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }
    public void Stampa()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona("Mario", "Rossi", 30);
        p.Stampa();
    }
}