Console.Clear();

Console.WriteLine ("Ciao! Questa è una calcolatrice.\t");
// comandi per fare inserire due numeri all'utente con conseguente conversione da stringa a valore
Console.Write ("Prego, inserisci il primo numero:");
double a = double.Parse(Console.ReadLine());
Console.Write ("Ora inserisci il secondo numero:");
double b = double.Parse(Console.ReadLine());

Console.WriteLine ();     //spazio

Console.WriteLine ("Quale operazione vuoi fare?\n"); 
//promt di scelta dell'operazione
Console.WriteLine ("- per somma digita 1");
Console.WriteLine ("- per differenza digita 2");
Console.WriteLine ("- per prodotto digita 3");
Console.WriteLine ("- per divisione digita 4");

Console.WriteLine ();     //spazio

Console.Write("Inserisci la tua scelta: ");
//acquisizione della scelta dell'utente
int operazione = int.Parse(Console.ReadLine ());    //definizione della variabile del risultato + collegamento del valore "operazione" al comando switch per restituzione calcolo
double risultato = 0; //assegnazione di un valore di default per farlo continuare

switch (operazione) 
{
    case 1:
        risultato = a + b;          //somma
    break;
    case 2:
        risultato = a - b;          //differenza
    break;
    case 3:
        risultato = a * b;          //prodotto
    break;
    case 4:
    if (b == 0)
{
    Console.WriteLine("Impossibile");
}     
        risultato = a / b;          //divisione
    break;
    default: 
        Console.WriteLine("Ritenta");           // messaggio di errore se numero digitato è maggiore di 4
    break;
}

Console.WriteLine($"Il risultato è: {risultato}");