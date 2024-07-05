//var viene utilizzato quando non sapiamo il tipo di dato che contiene la lista
//ad esempio, se avessimo una lista di stringhe avremmo dovuto scrivere 
List <string> numeri = new List <string> {"1"}
//oppure
List <int> numeri = new List <int> {1}
//non risuciamo a predeterminare quale tipo di dato andrà in lista (esempio, ci sono itpi di dati che potrebbero stalatere fuori da cicli dei quali non risuciamo a predeterminare il tipo)

var numeri = new List <int> {1, 2, 3, 4, 5};

foreach (var numero in numeri)
{
    Console.WriteLine(numero);  
}

//si può usare per i tipo anonimi