
List<string> nomi = new List<string>();
nomi.Add ("Mattia");
nomi.Add ("Matteo");
nomi.Add ("Daniele");
nomi.Add ("Ginevra");
nomi.Add ("Serghej");
nomi.Add ("Silvano");
nomi.Add ("Allison");
nomi.Add ("Sharon");

Random random = new Random(); //il costruttore random lo genero una sola volta fuori
// int estrazione = random.Next(1,8); COME AVEVO FATTO IO
 //invece di contare uno ad uno, basta utilizzare Count per contare quanti siamo

Console.WriteLine($"Il primo nome sorteggiato è {nomi[estrazione]}"); //estrae un numero da 1 a 8 e lo associa ad uno dei nomi in lista.

nomi.RemoveAt (estrazione); //removeAt (metodo) rimuove dalla Lista (che si chiama "nomi") il valore estrazione estratto prima
Console.WriteLine($"Il secondo nome sorteggiato è {nomi[(estrazione)]}");
nomi.RemoveAt (estrazione);

/*
Console.WriteLine($"I nomi non sorteggiati sono: ");
foreach (string nome in nomi)
{
    Console.WriteLine($"{nome}");
}
*/

int numero = nomi.Count;
while (nomi.Count > 0)
{
    int estrazione = random.Next(nomi.Count);
    Console.Write($"Poi abbiamo {nomi[(estrazione)]}. ");
    nomi.RemoveAt(estrazione);
    Console.WriteLine($"Ne restano {nomi.Count}. ");
}

