class programma
{
    static void Main ()
    {
        StampaMessaggio ("Ciao Mondo!");

        int risultato = Somma (3, 4);
        StampaMessaggio ($"La somma è {risultato}");
    }

    public static void StampaMessaggio (string messaggio) //funzione con ritorno di stringa
    {
        Console.WriteLine (messaggio);  
    }

    public static int Somma (int a, int b) // funzione con ritorno di valore
    {
        return a + b;
    }
}