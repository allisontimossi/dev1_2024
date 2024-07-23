class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero = int.Parse(null); //ciao non è un numero
        }
        catch (Exception e)
        {
            Console.WriteLine("Numero non può essere null ");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            return;
        }
    }

}