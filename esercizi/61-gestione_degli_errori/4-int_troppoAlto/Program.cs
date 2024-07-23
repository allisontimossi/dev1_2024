class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero = int.Parse("1000000000000"); //ciao non è un numero
        }
        catch (Exception e)
        {
            Console.WriteLine("Numero troppo alto");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
            return;
        }
    }
}