class Program
{
    static void Main ()
    {
        //richiamo di funzione Stampamessaggio
        StampaMessaggio ("Ciao Mondo!");

    //richiamo di funzione StampaMessaggioDefault

        StampaMessaggioDefault ("Mondo");
        StampaMessaggioDefault ("Mondo", "");

    //richiamo di funzione Somma
        int risultato = Somma (3, 4);
        StampaMessaggio ($"La somma è {risultato}");

    //richiamo di funzione SommaImpachettata
        int risultato4 = 0;
        SommaImpachettata (4, 5, out risultato4);
        StampaMessaggio ($"La somma è {risultato4}");

    //richiamo di funzione CalcolaMinMax
        int [] numeri = {3, 1, 4, 1, 5 , 9, 2, 6, 5, 3, 5};
        (int minimo, int massimo) risultato2 = CalcolaMinMax(numeri);
        StampaMessaggio ($"Valore minimo: {risultato2.minimo}");
        StampaMessaggio ($"Valore massimo: {risultato2.massimo}");

    //richiamo di funzione Dividi
        int? risultato3 = Dividi(10, 0);
        if (risultato3.HasValue)
        {
            StampaMessaggio ($"Il risultato è {risultato3.Value}");
        }
        else
        {
            StampaMessaggio ("Divisione per zero");
        }
    

    }

    public static void StampaMessaggio (string messaggio) //funzione con ritorno di stringa
    {
        Console.WriteLine (messaggio);  
    }

    public static void StampaMessaggioDefault (string nome, string saluto = "Ciao") //funzione con ritorno di stringa
    {
        Console.WriteLine ($"{saluto}, {nome}!");  
    }

    public static int Somma (int a, int b) // funzione con ritorno di valore
    {
        return a + b;
    }

    static void SommaImpachettata (int a, int b, out int risultato4)
    {
        risultato4 = a + b;
    }

    static (int, int) CalcolaMinMax (int[] numeri)
    {
        int minimo = numeri.Min ();
        int massimo = numeri.Max ();
        return (minimo, massimo);
    }

    static int? Dividi (int a, int b)
    {
        if (b==0) {return null;}
        return a / b;
    }
}