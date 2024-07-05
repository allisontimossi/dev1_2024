Dictionary<string, List<int>> registroClasse = new Dictionary<string, List<int>>();
registroClasse["Marco"] = new List<int >{7, 8, 9};
registroClasse["Laura"] = new List<int> {6, 7, 8};

registroClasse["Marco"].Add(10);

foreach (KeyValuePair<string, List<int>> studente in registroClasse) 
{
    Console.WriteLine($"Studente: {studente.Key} - Voti: {string.Join("- ", studente.Value)}"); //Join è un metodo che unisce gli elementi di una sequenza ma separarlo con l'elemento che vogliamo
}