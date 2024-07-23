class Program
{
    static void Main(string[] args)
    {
        try
        {
            StackOverflow(); 
        }
        catch (Exception e)
        {
            Console.WriteLine("StackOverflow");
            Console.WriteLine($"ERRORE NON TRATTATO:{e.Message}");
            return;
        }
    }
    static void StackOverflow()
    {
        StackOverflow(); //richiamiamo una funzione che è se stessa, questo genera errore
    }
}