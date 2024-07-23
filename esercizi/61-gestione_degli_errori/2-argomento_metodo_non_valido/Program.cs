class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero = int.Parse("ciao"); //ciao non è un numero
        }
        catch (Exception e)
        {
            Console.WriteLine("Numero non valido ");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            return;
        }
    }
    finally
    {
        Console.WriteLine("Fine del programma");
    }
}