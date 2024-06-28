List<string> nomi = new List<string>(); //NON DOBBIAMO PREDEFINIRE IL NUMERO DI ELEMENTI
nomi.Add("Mario");
nomi.Add ("Luigi");
nomi.Add ("Bowser");
nomi.Add ("Ginevra");
Console.WriteLine($"Ciao {nomi[3]}, {nomi[0]}, {nomi [2]}, {nomi[1]}");

//volendo
nomi.AddRange(new string[] { "Mario", "Luigi","Bowser"}); //per creare la lista senza scrivere nomi.Add

//oppure
List<string> nomi = new List<string>{"Mario", "Luigi", "Giovanni"};