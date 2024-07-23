class Program
{
    static void Main(string[] args)
    {
        try
        {
            int zero = 1; //ciao non è un numero
            int numero = 1 / zero;
        }
        catch (Exception e)
        {
            Console.WriteLine("Divisione per zero");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
            return;
        }
        finally //esegue sempre a prescindere dall'eccezione
        {
            Console.WriteLine("Riproduci lo stesso");
        }
    }
}