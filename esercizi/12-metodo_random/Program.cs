//utilizzo di random

//dichiaro oggetto random
//intervallo semiaperto, aggiungere 1
Random random = new Random(); //new è un costruttore, ma serve il volante
int numero = random.Next(-10,10); //il numero estratto è compreso tra .. e .. (è il volante)

Console.WriteLine($"Il numero casuale è {numero}");
