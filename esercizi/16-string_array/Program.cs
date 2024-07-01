string [] nomi = new string [3];
nomi[0] = "Mario";
nomi[1] = "Luigi";
nomi[2] = "Bowser";

foreach (string s in nomi)
{
    Console.WriteLine($"Ciao {s}");
}

//volendo
nomi.AddRange(new string[] { "Mario", "Luigi","Bowser"}); //per creare la lista senza scrivere nomi.Add
