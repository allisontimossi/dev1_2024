Console.Write ("Inserisci l'identificativo numerico del giorno settimana:\t");

//int giorno = Console.ReadLine()!; //SI USA INT PERCHÈ È UN NUMERO!!

//Serve convertire in numero qualcosa che scriviamo come stringa
int giorno =int.Parse(Console.ReadLine());
switch (giorno) 
{
    case 1:
        Console.WriteLine("Lunedì");
    break;
    case 2:
        Console.WriteLine("Martedì");
    break;
    case 3:
        Console.WriteLine("Mercoledì");
    break;
    case 4:
        Console.WriteLine("Giovedì");
    break;
    case 5:
        Console.WriteLine("Venerdì");
    break;
    case 6:
        Console.WriteLine("Sabato");
    break;
    case 7:
        Console.WriteLine("Domenica");
    break;
    default:
        Console.WriteLine("Il numero non corrisponde a nessun giorno della settimana");
    break;
}