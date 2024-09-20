class Persona
{
    private string nome;
    private string cognome;
    private int eta;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }   
    }
    public string Cognome
    {
        get { return cognome; }
        set { cognome = value; }    
    }
    public int Eta
    {
        get { return eta; }
        set { eta = value; }    
    }
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
        p.Nome="Luigi"; //INIZIALIZZA MARIO CON LUIGI
        p.Stampa();
    }
}
/*
Better control of class members (reduce the possibility of yourself (or others) to mess up the code)
Fields can be made read-only (if you only use the get method), or write-only (if you only use the set method)
Flexible: the programmer can change one part of the code without affecting other parts
Increased security of data
*/