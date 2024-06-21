// comandi per fare inserire due numeri all'utente con conseguente conversione da stringa a valore
Console.Write ("Inserisci il primo numero:\t");
int a = int.Parse(Console.ReadLine());
Console.Write ("Inserisci il secondo numero:\t");
int b = int.Parse(Console.ReadLine());


Console.WriteLine ("Quale operazione vuoi fare?1\n");
Console.WriteLine ("- per somma digita 1");
Console.WriteLine ("- per differenza digita 2");
Console.WriteLine ("- per prodotto digita 3");
Console.WriteLine ("- per divisione digita 4");

int somma = a + b;
int differenza = a - b;
int prodotto = a * b;
int divisione = a / b; 


int operazione = int.Parse(Console.ReadLine ());    // collego il valore "operazione" allo switch per far restituire il calcolo
switch (operazione) 
{
    case 1:
        Console.WriteLine($"{somma}");
    break;
    case 2:
        Console.WriteLine($"{differenza}");
    break;
    case 3:
        Console.WriteLine($"{prodotto}");
    break;
    case 4:
        Console.WriteLine($"{divisione}");
    break;
    default: 
        Console.WriteLine("Ritenta");
    break;
}