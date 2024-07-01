## VERSIONE 1
# Esempio di elenco
```c#
List<string> nomi = new List<string>();
nomi.Add("Mario");
nomi.Add("Luigi");
nomi.Add("Giovanni");
```
// Utilizzo del random: la app sorteggia un nome e lo visualizza.
```c#
Random random = new Random();

int indice = random.Next(nomi.Count);

Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
```
```c#
// Inserimento di più nomi in contemporanea: 

// array
nomi.AddRange(new string[] { "Mario", "Luigi", "Giovanni" });

// List
List<string> nomi = new List<string> { "Mario", "Luigi", "Giovanni" };
List<string> nomi = ["Mario", "Luigi", "Giovanni"];
```
## VERSIONE 2
# NomeLista.RemoveAt(indice): rimozione del nome sorteggiato
```c#
int indice = random.Next(nomi.Count); //il computer genera un nome associandolo ad un indice
nomi.RemoveAt(indice); //il nome generato viene rimosso dalla lista
```
```c#
List<string> nomi = new List<string>();
nomi.Add("Mario");
nomi.Add("Luigi");
nomi.Add("Giovanni");

Random random = new Random();
int indice = random.Next(nomi.Count);

Console.WriteLine("Elenco partecipanti:");
foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}

Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
nomi.RemoveAt(indice);

Console.WriteLine("Elenco partecipanti:");
foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}
```
## VERSIONE 3
# Utilizzo del while: la app continua a sorteggiare finchè ci sono nomi nella lista
```c#
while (nomi.Count > 0)
{
    int indice = random.Next(nomi.Count);                       // generazione di un numero casuale tra 0 e il numero di elementi della lista
    Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}"); // visualizzazione del nome sorteggiato
    nomi.RemoveAt(indice);                                      // rimozione del nome sorteggiato dalla lista
    Console.WriteLine("Elenco partecipanti:");                  // visualizzazione dell'elenco dei partecipanti
    foreach (string nome in nomi)
    {
        Console.WriteLine(nome);
    }
}
```
## VERSIONE 4
# "Spostamento" di un indice da una lista ad un'altra: la app toglie dalla lista il nome sorteggiato e lo aggiunge ad una seconda lista
```c#
List<string> nomi = new List<string> { "Mario", "Luigi", "Giovanni" };
List<string> sorteggiati = new List<string>(); //creazione di una lista vuota

int indice = random.Next(nomi.Count); //dichiarazione della variabile indice
string sorteggiato = nomi[indice];  // dichiarazione della variabile sorteggiato

nomi.RemoveAt(indice);
sorteggiati.Add(sorteggiato);
```
//esempio completo
nomi.RemoveAt(indice);
```c#
 List<string> nomi = new List<string>();
nomi.Add("Mario");
nomi.Add("Luigi");
nomi.Add("Giovanni");

List<string> sorteggiati = new List<string>(); //creazione di una lista vuota

while (nomi.Count > 0)
{
    int indice = random.Next(nomi.Count);
    string sorteggiato = nomi[indice];  // estrazione del nome sorteggiato

    Console.WriteLine($"Il nome sorteggiato è {sorteggiato}");

    // ----------------------------------------------------------------------------
    nomi.RemoveAt(indice);
    sorteggiati.Add(sorteggiato);
    // ----------------------------------------------------------------------------

    Console.WriteLine("Elenco partecipanti:");
    foreach (string nome in nomi)
    {
        Console.WriteLine(nome);
    }

    Console.WriteLine("Elenco sorteggiati:");
    foreach (string nome in sorteggiati)
    {
        Console.WriteLine(nome);
    }
}
```
## VERSIONE 5
# Inserimento di un nuovo indice
```c#
Console.Write("Nome partecipante: ");
nome = Console.ReadLine();
partecipanti.Add(nome);
```
# L'app permette di uscire
```c#
do
{
    switch (scelta)
    {
        case 1:
            
            break;
        case 2:
            
            break;
        case 3:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}
while (scelta != 3); // il ciclo continua finchè la scelta è diversa da 3
```
//esempio completo
```c#
//----eseguo fuori dai loops----------------------------------------------------------
List<string> partecipanti = new List<string>();
string nome;
int scelta;
//------------------------------------------------------------------------------------
do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Esci");
    Console.Write("Scelta: ");
    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            partecipanti.Add(nome);
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}
while (scelta != 3); // il ciclo continua finchè la scelta è diversa da 3
```
## VERSIONE 6
# Ordinamento liste: la app permette di ordinare la lista dei partecipanti in ordine alfabetico
```c#
partecipanti.Sort(); // ordinamento della lista in ordine alfabetico tramite il metodo Sort
partecipanti.Reverse(); // ordinamento della lista in ordine alfabetico inverso tramite il metodo Reverse (da usare abbinato a partecipanti.Sort())
```

//esempio completo
```c#
List<string> partecipanti = new List<string>();
string nome;
int scelta;
do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Ordina partecipanti");
    Console.WriteLine("4. Esci");
    Console.Write("Scelta: ");
    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            partecipanti.Add(nome);
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
            Console.WriteLine("1. Ordine crescente");
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");
            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort(); // ordinamento della lista in ordine alfabetico tramite il metodo Sort
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse(); // ordinamento della lista in ordine alfabetico inverso tramite il metodo Reverse
            }
            else
            {
                Console.WriteLine("Scelta non valida");
            }
            break;
        case 4:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
} while (scelta != 4);
```
## VERSIONE 7
# metodo NomeLista.Contains(nomeDaCercare): ricerca di un indice presente nella lista: 

```c#
Console.Write("Nome partecipante: ");
nome = Console.ReadLine();
if (partecipanti.Contains(nome))
{
    Console.WriteLine("Il partecipante è presente nella lista");
}
else
{
    Console.WriteLine("Il partecipante non è presente nella lista");
}
```
## VERSIONE 8
# Ricerca di un indice e inserimento qualora l'indice non ci sia
```c#
if (partecipanti.Contains(nome)) //ricerca e inserimento
{
    Console.WriteLine("Presente");
}
else
{
    partecipanti.Add(nome);
}
break;
```
// esempio parziale
```c#
Console.Write("Nome partecipante: ");
nome = Console.ReadLine();
if (partecipanti.Contains(nome)) //ricerca e inserimento
{
    Console.WriteLine("Il partecipante è già presente nella lista");
}
else
{
    partecipanti.Add(nome);
}
break;
```
//// esempio completo
```c#
List<string> partecipanti = new List<string>();
string nome;
int scelta;

do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Ordina partecipanti");
    Console.WriteLine("4. Cerca partecante");
    Console.WriteLine("5. Esci");
    Console.Write("Scelta: ");
    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è già presente nella lista");
            }
            else
            {
                partecipanti.Add(nome);
            }
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
            Console.WriteLine("1. Ordine crescente");
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");
            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort();
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse();
            }
            else
            {
                Console.WriteLine("Scelta non valida");
            }
            break;
        case 4:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 5:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
} while (scelta != 5);
```

## VERSIONE 9
# nomeLista.Remove(nome): eliminazione da lista
```c#
Console.Write("Nome partecipante: ");
nome = Console.ReadLine(); 
nomeLista.Remove(nome);
```
//esempio completo
```c#
List<string> partecipanti = new List<string>();
string nome;
int scelta;

do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Ordina partecipanti");
    Console.WriteLine("4. Cerca partecante");
    Console.WriteLine("5. Elimina partecipante");
    Console.WriteLine("6. Esci");
    Console.Write("Scelta: ");
    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è già presente nella lista");
            }
            else
            {
                partecipanti.Add(nome);
            }
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
            Console.WriteLine("1. Ordine crescente");
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");
            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort();
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse();
            }
            else
            {
                Console.WriteLine("Scelta non valida");
            }
            break;
        case 4:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 5:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                partecipanti.Remove(nome);
                Console.WriteLine("Il partecipante è stato eliminato dalla lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 6:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
} while (scelta != 6);
```
## VERSIONE 10
# Modifica di un indice presente in lista
```c#
Console.Write("Nuovo nome: "); //inserimento del nome con cui sostituire il vecchio
string nuovoNome = Console.ReadLine();
int indice = partecipanti.IndexOf(nome); // IndexOf restituisce l'indice del nome nella lista
partecipanti[indice] = nuovoNome;
Console.WriteLine("Il partecipante è stato modificato nella lista"); //feedback di modifica
```
//esempio completo
```c#
case 6:
    Console.Write("Nome partecipante: ");
    nome = Console.ReadLine();
    if (partecipanti.Contains(nome))
    {
        Console.Write("Nuovo nome: ");
        string nuovoNome = Console.ReadLine();
        int indice = partecipanti.IndexOf(nome); // IndexOf restituisce l'indice del nome nella lista
        partecipanti[indice] = nuovoNome;
        Console.WriteLine("Il partecipante è stato modificato nella lista");
    }
    else
    {
        Console.WriteLine("Il partecipante non è presente nella lista");
    }
    break;
```