using System.Security.Cryptography.X509Certificates;


class View{
    private Database _db;

    public View(Database db) {
        _db = db;
    }

    // Menu principale dell'app (lato view)
    //Non sono necessari requisiti di controllo perché subentrerà il controllo tramite Spectre.Console
    public void ShowMainMenu(){

        Console.WriteLine("1. Aggiungi libro");
        Console.WriteLine("2. Aggiungi autore");
        Console.WriteLine("3. Mostra autori");
        Console.WriteLine("4. Cerca libro");
        Console.WriteLine("5. Aggiungi utente");
        Console.WriteLine("6. Nuovo Prestito");
        Console.WriteLine("10. Esci");
    }

// Lettura dell'input dell'utente, sia di tipo string che di tipo int
    public string GetInput(){
        return Console.ReadLine();
    }
    public int GetIntInput(){
        return int.Parse(Console.ReadLine());
    }

    public void ViewAuthors(List<Autore> autori){
        foreach (var autore in autori)
        {
            Console.WriteLine($"ID: {autore.Id} - {autore.Cognome} {autore.Nome}");
        }
    }

    public void ViewGenres(List<Genere> generi){
        foreach (var genere in generi)
        {
            Console.WriteLine($"ID: {genere.Id} - {genere.NomeGenere} - Scaffale: {genere.Scaffale}");
        }
    }

    public void ViewBooks(List<Libri> libri){
        foreach (var libro in libri)
        {
            Console.WriteLine ($"Titolo: {libro.Titolo} - Disponibilità: {libro.Disponibilità} - {libro.Scaffale}");
        }
    }

    public void ViewUsers(List<User> utenti){
        foreach (var utente in utenti)
        {
            Console.WriteLine($"ID: {utente.Id} - {utente.Nome} {utente.Cognome}");
        }
    }
}