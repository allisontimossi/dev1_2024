Dictionary<string,bool> presenze = new Dictionary<string, bool>();

presenze["Mario Rossi"] = true;
presenze["Luca Bianchi"] = false; 
foreach (KeyValuePair<string,bool> dipendente in presenze)
{
    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}; Stato: presente"); //per concatenarela key e il valore
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}; Stato: assente");
    }
}

//per cambiare lo stato MANUALMENTE

//Il programma chiede di quale dipendente si vuole cambiare lo stato

Console.WriteLine($"Si vuole cambiare lo stato di quale dipendente?");
string nomeDipendente = Console.ReadLine(); 

if (presenze.ContainsKey (nomeDipendente))  //ricerca all'interno del dizionario il nome del dipendente digitato
{
    presenze[nomeDipendente] = !presenze [nomeDipendente]; //se il nome digitato è presente all'interno della lista viene cambiato (simbolo ! = diverso)
}
else
{
    Console.WriteLine   ("Il dipendente non è presente sulla lista");
}

//stampa della lista aggiornata
foreach (KeyValuePair<string,bool> dipendente in presenze)
{
    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}; Stato: presente"); //per concatenarela key e il valore
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}; Stato: assente");
    }
}