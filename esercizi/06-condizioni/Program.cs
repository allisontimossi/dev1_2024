// Un blocco di codice è compreso tra parentesi graffe {} e può contenere uno o più statement 
// Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera

/*
Le condizioni possono essere:
if
if-else
if-else if-else
switch
*/

// Una variabile deve definire la condizione: una parte sarà dichiarazone del contenuto che poi verrà utilizzato come argomento

    //IF
/*
if - se il numero = 10, stampa il numero
int numero = 10;
if (numero == 10) // utilizzo l'operatore confronto, non serve " ; " se lo metto al centro 
{
    Console.WriteLine("Il numero è 10");
}
*/


    // IF ELSE
/*
int numero = 10;
if (numero == 10) 
{
    Console.WriteLine("Il numero è 10");
}
else        //restituisce un altro valore in caso di false
{
Console.WriteLine("Il numero NON è 10");
}
*/

//IF  ELSE IF  ELSE
/*
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
*/

//SWITCH

/*
int giorno = 10;
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
/* 