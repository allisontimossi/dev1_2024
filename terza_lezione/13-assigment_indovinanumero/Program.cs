
Random random = new Random();
int numero = random.Next(1,100);

Console.Write("Ciao, prova a indovinare un numero da 1 a 100. Prego, prova a inserire un numero: ");
int tentativo = int.Parse(Console.ReadLine());

if (tentativo == numero)
{
    Console.WriteLine("Complimenti!");
}
else
{
    Console.WriteLine("Ritenta");
}
//pari o dispari (diviso 2)
//20 - 80
//40 - 60
Console.WriteLine($"Il numero casuale è {numero}");

int numero = 10;

do
{
    Console.WriteLine(numero);
    numero--;
}
while (numerotentativo < 5);