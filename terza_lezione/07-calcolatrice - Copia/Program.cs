// comandi per fare inserire due numeri all'utente con conseguente conversione da stringa a valore
Console.Write ("Inserisci il primo numero:\t");
int a = int.Parse(Console.ReadLine());
Console.Write ("Inserisci il secondo numero:\t");
int b = int.Parse(Console.ReadLine());

Console.WriteLine ();     //spazio

Console.WriteLine ("Quale operazione vuoi fare?\n"); 

Console.WriteLine ("- per somma digita 1");
Console.WriteLine ("- per differenza digita 2");
Console.WriteLine ("- per prodotto digita 3");
Console.WriteLine ("- per divisione digita 4");

Console.WriteLine ();     //spazio

double divisione = (double)a / b;

if (b == 0)
{
    Console.WriteLine("Impossibile");
};

int operazione = int.Parse(Console.ReadLine ());    // //definizione della variabile del risultato + collegamento del valore "operazione" al comando switch per restituzione calcolo
switch (operazione) 
{
    case 1:
        Console.WriteLine("=", a + b);          //somma
    break;
    case 2:
        Console.WriteLine("=", a - b);          //differenza
    break;
    case 3:
        Console.WriteLine("=", a * b);          //prodotto
    break;
    case 4:
        Console.WriteLine($"= {divisione}");    //divisione
    break;
    default: 
        Console.WriteLine("Ritenta");           // messaggio di errore se numero digitato è maggiore di 4
    break;
}