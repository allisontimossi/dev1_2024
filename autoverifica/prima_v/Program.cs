// Utilizzare metodo random.Next per genreare un numero casuale compreso tra 1 e 10 PER 10 VOLTE e calcolarne la somma

int numeroVolte;
Random random = new Random(); 
int risultato = 0;

for (numeroVolte = 0; numeroVolte <=10; )
{
    int addendo = random.Next(1,11);
    risultato += addendo;
    Console.Write($" {risultato} ");
    numeroVolte++;       //meglio metterlo in fondo
}
Console.WriteLine($"La somma è: {risultato}");

