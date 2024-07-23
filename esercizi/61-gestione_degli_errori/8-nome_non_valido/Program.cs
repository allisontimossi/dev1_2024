
class Program
{
    static void Main(string[] args)
    {
        string nome = null;
        try
        {
            Console.WriteLine(nome.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine("Il nome non è valido");
            Console.WriteLine($"ERRORE NON TRATTATO:{e.Message}");
            return;
        }
    }
}