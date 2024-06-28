
Random random = new Random();
int numero = random.Next(1,100);

Console.WriteLine($"Il numero casuale è {numero}");
int tentativo = 0;

Console.Write("Ciao, prova a indovinare un numero da 1 a 100. Prego, prova a inserire un numero: ");


do
{
int tentativo = int.Parse(Console.ReadLine()); 
}
while (numero == tentativo);

if (tentativo == numero)
{
    Console.WriteLine("Complimenti!");
}
else
{
    Console.WriteLine("Ritenta");
}