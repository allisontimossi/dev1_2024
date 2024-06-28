List<int> numeri = new List<int>();
numeri.Add(10);
numeri.Add(20);
numeri.Add(30);

Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}");

Console.WriteLine($"Il numero di elementi è {numeri.Count}");

List<string> nomi = new List<string>(); //NON DOBBIAMO PREDEFINIRE IL NUMERO DI ELEMENTI
nomi.Add("Mario");
nomi.Add ("Luigi");
nomi.Add ("Bowser");
nomi.Add ("Ginevra");
Console.WriteLine($"Ciao {nomi[3]}, {nomi[0]}, {nomi [2]}, {nomi[1]}");
Console.WriteLine($"Il numero di elementi è {nomi.Count}");