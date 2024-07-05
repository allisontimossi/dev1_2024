# Esercitazioni
## 01 Tipi di dati
<details>
    <summary> Visualizza il codice </summary>

```c#
lòkk
```
</details>

## 02 Operatori
<details>
    <summary> Visualizza il codice </summary>

```c#
lòkk
```
</details>

## 03 Tipi di dati ed operatori
<details>
    <summary> Visualizza il codice </summary>

```c#
int numero;  //inizializzo la variabile numero con il valore 10
numero = 10; //dichiaro una variabile di tipo intero

int età = 20;       //dichiaro ed inizializzo una variabile di tipo intero
Console.WriteLine("L'età è:" +età);

// Esempi di modifiche ad un intero:

età++;          //permette di aggiungere un'unità alla variabile diciarata
età+= 5;        //permette di aggiungere QUANTO VUOI alla variabile diciarata

int addendo = random.Next(1,11);
età+= addendo   //permette di aggiungere un numero random  alla variabile dichiarata
```
</details>

## 04 Esempio di concatenazione
<details>
    <summary> Visualizza il codice </summary>

```c#
Console.Write ("Inserisci il tuo nome: \t");
string nome = Console.ReadLine()!;      //dichiarazione della stringa "nome"
int codice = 123456;                    //dichiarazione del numero intero "123456"

Console.WriteLine ($"{nome} - {codice}");
```
</details>

## 05 Condizioni
<details>
Le condizioni possono essere:
- if
- if-else
- if-else if-else
- switch


    <summary> Visualizza il codice </summary>

```c#
//IF
int numero = 10;    //se il numero = 10, stampa il numero
if (numero == 10)   // utilizzo l'operatore confronto / non serve " ; " se lo metto al centro 
{
    Console.WriteLine("Il numero è 10");
}

// IF ELSE

int numero = 10;
if (numero == 10) 
{
    Console.WriteLine("Il numero è 10");
}
else        //restituisce un altro valore in caso di false
{
Console.WriteLine("Il numero NON è 10");
}

//IF  ELSE IF  ELSE

int numero = 9;
if (numero == 10) 
{
    Console.WriteLine("Il numero è 10");
}
else if (numero > 10)
{
    Console.WriteLine("Il numero è maggiore di 10");
}
else
{
Console.WriteLine("Il numero è minore di 10");
}

//SWITCH

int giorno =int.Parse(Console.ReadLine()); //permette di digitare un numero 
switch (giorno) //giorno è la condizione
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
```
</details>

## 07 Calcolatrice
<details>
    <summary> Visualizza il codice </summary>

```c#
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
```
</details>

## 08 While
<details>
    <summary> Visualizza il codice </summary>

```c#
//DO

A partire dal numero digitato ..
int numero = 10; 

.. si ferma finché non si verifica la condizione sopra (quindi non può scendere sotto a 0)
while (numero > 0)
{
    Console.WriteLine(numero);
    numero--;
}


```
</details>

## 09 Do - While
<details>
    <summary> Visualizza il codice </summary>

```c#
// la differenza col primo è che qua stampa almeno il primo int (in questo caso 10)

int numero = 10;

do 
{
Console.WriteLine(numero);
numero--;
}
while (numero > 11);

```
</details>

## 10 For
<details>
    <summary> Visualizza il codice </summary>

```c#
//Esegue il comando per tot volte (per un numero di volte compreso tra 0 e 10 lui aggiunge 1)

int n = 13; //facciamo girare per 10 volte il comando +1
for (int i = 01; i <= n;)
{
    Console.WriteLine(i);
    i++;
}
```
</details>

## 11 For-each
<details>
    <summary> Visualizza il codice </summary>

```c#
//for each senza array

string scritta = "ciao";
foreach (char lettera in scritta)
{
    Console.WriteLine(lettera);
}
```
</details>

## 12 Random
<details>
    <summary> Visualizza il codice </summary>

```c#
Random random = new Random(); //si scrive il costruttore
int numero = random.Next(-10,10); //il numero estratto è compreso tra .. e .. 

Console.WriteLine($"Il numero casuale è {numero}");
```
</details>

## 13 Indovina numero
### Singolo tentativo:
<details>
    <summary> Visualizza il codice </summary>

```c#

```
</details>

### Conteggio tentativi:

<details>
    <summary> Visualizza il codice </summary>

```c#

```
</details>

### Limite tentativi:

<details>
    <summary> Visualizza il codice </summary>

```c#

```
</details>

### Indovina numero (Pari dispari)
<details>
    <summary> Visualizza il codice </summary>

```c#

```
</details>

## 14 FizzBuzz
<details>
    <summary> Visualizza il codice </summary>

```c#
Console.Write ("Inserisci il tuo nome: \t");
string nome = Console.ReadLine()!;

int codice = 123456;

Console.WriteLine ($"{nome} - {codice}");
```
</details>

## 15 Strutture di dati
### Array
<details>
    <summary> Visualizza il codice </summary>

```c#
// è necessario definire la "grandezza della cartella"
//in caso di stringhe, abbiamo le virgolette
string [] nomi = new string [3];
nomi[0] = "Mario";
nomi[1] = "Luigi";
nomi[2] = "Bowser";

Console.WriteLine($"Ciao {nomi[0]}, {nomi [1]}, {nomi[2]}");

//in caso di interi non sono necessarie le virgolette
int [] numeri = new int [3];
numeri[0] = 10;
numeri[1] = "20";
numeri[2] = 30;
Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}");

nomeArray.Length // definisce la grandezza del contenitore:
Console.WriteLine($"Il numero di elementi è {nomi.Length}");
```
</details>

### Liste

<details>
    <summary> Visualizza il codice </summary>

```c#
//in caso di stringhe
List<string> nomi = new List<string>(); //Rispetto ad Array, NON DOBBIAMO PREDEFINIRE IL NUMERO DI ELEMENTI
nomi.Add("Mario");
nomi.Add ("Luigi");
nomi.Add ("Bowser");
nomi.Add ("Ginevra");

//in generale, per aggiungere basta: 
nomeLista.Add("");
//oppure
List<string> nomi = new List<string>{"Mario", "Luigi", "Giovanni"};


//in caso di interi
List<int> numeri = new List<int>();
numeri.Add(10);
numeri.Add(20);
numeri.Add(30);

List<int> numeri = new List<int>{10, 20, 30};

nomeLista.Count // conta il numero di elementi all'interno
Console.WriteLine($"Il numero di elementi è {numeri.Count}");
```
</details>
