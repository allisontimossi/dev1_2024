*/
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] numeri = new int [int.MaxValue]; //.MaxValue restituisce il massimo di qualcosa 
            //int.MaxValue al massimo può essere    2.147.483.647
            //un array ha una dimensione massima di 2.147.483.591
        }
        catch (Exception e)
        {
            Console.WriteLine("Memoria insufficiente");
            Console.WriteLine($"ERRORE NON TRATTATO:{e.Message}");
            return;
        }
    }
}