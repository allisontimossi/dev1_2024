char aiuto;
int tentativi = 0;

int min = 1;
int max = 100;

bool programmaVa = true; //definisco variabile booleana

Random random = new Random(); 

Console.WriteLine("Ciao! Pensa ad un numero da 1 a 100, provo a indovinarlo in 10 tentativi.");

while (programmaVa) //finché programmaVa è vero, stiamo dentro al while
{
    int numero = random.Next(min, max+1); //ad ogni ciclo, sulla base dei comandi dati, viene "aggiornato" il range
    Console.WriteLine($"Il numero secondo me è {numero}.");
    Console.WriteLine("Cosa mi dici? \n(c) Ho indovinato \n(+) Più alto\n(-) Più basso");
    Console.WriteLine("Inserire la scelta:");
    
    aiuto = Console.ReadKey(true).KeyChar; //esempio di inserimento carattere facendo sparire il carattere digitato

    switch (aiuto) 
        {
            case '+':
                min = (min+max)/2 + min; //aggiorna il range
                Console.Clear();
            break;
            case '-':
 //aggiorna il range 
                Console.Clear();
            break;
            case 'c':
                Console.Clear();
                Console.WriteLine($"Ho vinto in {tentativi+1} tentativi!");
                programmaVa = false;    //il programma smette di funzionare ed esce dal while
            break;
            default:
                Console.WriteLine("Digita una delle opzioni disponibili.");
            break;
        }

    if (tentativi == 10)
    {
        Console.Clear();
        Console.WriteLine("Va bene, ho perso.");
        programmaVa = false;        //il programma smette di funzionare ed esce dal while
        
    }
    tentativi++; //ad ogni ciclo incrementa il numero di tentativi fino a 5
}
