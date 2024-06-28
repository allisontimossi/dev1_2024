
List<string> partecipanti = new List<string>();
partecipanti.Add ("Mattia");
partecipanti.Add ("Matteo");
partecipanti.Add ("Daniele");
partecipanti.Add ("Ginevra");
partecipanti.Add ("Serghej");
partecipanti.Add ("Silvano");
partecipanti.Add ("Allison");
partecipanti.Add ("Sharon");

List<string> sorteggiati = new List<string>();

Random random = new Random(); //la generazione del random la teniamo esterna

//genero liste e istanzio l'oggetto random
while (nomi.Count > 0) 
{
    int indice = random.Next(nomi.Count);
    string sorteggiato = nomi [indice];     //sorteggiato corrisponde all'indice random della lista nomi

    Console.WriteLine ("Il nome sorteggiato è" + sorteggiato);
    
    //togliamo dalla lista nome quell'indice lì
    nomi.RemoveAt (indice);
    sorteggiati.Add (sorteggiato);
    //------------------------------------------------------------------------
    Console.WriteLine("Elenco partecipanti")
    foreach (string nome in partecipanti)
    {
        Console.WriteLine(nome);
    }

    Console.WriteLine("Elenco sorteggiati:");
    foreach (string nome in sorteggiati)
    {
        Console.WriteLine(nome);
    }
}

