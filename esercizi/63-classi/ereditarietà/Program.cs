class Persona
{
    public string nome;
    public string cognome;
    public int eta;
    public Persona (string nome, string cognome, int eta) //queto passaggio serve per inizializzare i campi dell'oggetto con valori specifici altrimenti i campi non vengono inizializzati
    {
        this.nome = nome; //è una referenza a qualcosa che ho già
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

class Studente: Persona //definizione di una classe Studente che eredita dalla classe Persona i membri dati e i membri funzione non privati
{
    public string corso;
    public Studente (string nome, string cognome, int eta, string corso) : base (nome, cognome, eta)
    {
        this.corso = corso;
    }
    public void StampaCorso()
    {
        Console.WriteLine ($"Corso: {corso}");
    }
}
class Program{
    static void Main (string[] args)   
    {
        Studente s = new Studente ("Mario", "Rossi", 30, "Informatica");
        s.Stampa();
        s.StampaCorso();
    }
}
