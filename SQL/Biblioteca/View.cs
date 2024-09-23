using System.Security.Cryptography.X509Certificates;

class View{
    private Database _db;

    public View(Database db) {
        _db = db;
    }
    public void ShowMainMenu(){
        Console.Clear();
        Console.WriteLine("1. Aggiungi libro");
        Console.WriteLine("2. Aggiungi autore");
        Console.WriteLine("3. Mostra autori");
        Console.WriteLine("4. Cerca libro");
        Console.WriteLine("5. Aggiungi utente");
    }
    public string GetInput(){
        return Console.ReadLine();
    }
    public int GetIntInput(){
        return int.Parse(Console.ReadLine ());
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

}