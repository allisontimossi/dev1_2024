

string path = @"test.csv";


if (!File.Exists(path))
{
    File.Create(path).Close();
}

while (true)

{
    List<string> nomi = new List<string>(File.ReadAllLines(@"test.csv"));
    Console.WriteLine("Inserisci nome, cognome ed età");
    string nome = Console.ReadLine();
    string cognome = Console.ReadLine();   
    string eta = Console.ReadLine();

    string anagrafica = ($"{nome}, {cognome}, {eta}");

    if (nomi.Contains(anagrafica))
    {
        Console.WriteLine("Nome già presente");
    }
    else
    {
        File.AppendAllText (path, anagrafica + "\n");
        Console.WriteLine("Vuoi inserire un altro nome?");
        string risposta = Console.ReadLine(); 
        if (risposta == "n")
        {
            break;
        }   
    }
}
