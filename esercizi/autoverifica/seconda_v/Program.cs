// utilizzare un ciclo do-while per ripetere il menu di opzione finché l'utente non sceglie di uscire, mantenendo il menu sempre visualizzato
int scelta;

do
{  
    Console.Clear(); 
    Console.WriteLine("Menu di selezione \n1. Opzione 1 \n2. Opzione 2 \n3. Opzione 3");
    Console.Write("Inserisci la scelta: ");
    
    scelta = int.Parse(Console.ReadLine ());

    switch (scelta)
    {
        case 1:
            
            Console.WriteLine("Hai scelto la prima opzione.");
            
        break;
        case 2:
            Console.WriteLine("Hai scelto la seconda opzione.");
        break;
        case 3:
            
            Console.WriteLine("Uscita in corso..");
            

        break;
        default:
            
            Console.WriteLine("Errore");
        break;
    }
    if (scelta != 8)
    {
        Console.WriteLine("Premi un tasto per continuare..");
        Console.ReadKey(); 
    }
}
while (scelta != 3);