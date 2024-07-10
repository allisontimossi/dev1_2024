List<string> nomi = new List<string>{"Mario", "Luigi", "Giovanni"};

foreach (var n in nomi)
{
    Console.WriteLine("" + n);
}

Console.Write("Inserire nome da togliere:");
string nomeDaTogliere = Console.ReadLine();    
nomi.Remove (nomeDaTogliere);

foreach (var n in nomi)
{
    Console.WriteLine("" + n);
}