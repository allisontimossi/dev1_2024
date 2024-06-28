List<string> nomi = new List<string>();
nomi.Add ("Mattia");
nomi.Add ("Matteo");
nomi.Add ("Daniele");
nomi.Add ("Ginevra");
nomi.Add ("Serghej");
nomi.Add ("Silvano");
nomi.Add ("Allison");
nomi.Add ("Sharon");

List<string> partecipanti = new List<string>();
Console.WriteLine("1. Inserisci partecipante /n 2. Visualizza partecipanti /n 3. Esci");
Console.Write("Scelta: "); //acquisizione della scelta dell'utente
int scelta = int.Parse(Console.ReadLine ());

string sorteggiato = partecipanti [indice];  
switch (scelta) 
{
    case 1:
        Console.WriteLine("Inserisci il nome del partecipante:");
        string nomePartecipante = Console.ReadLine ();
        nomi.RemoveAt (nomePartecipante);
        partecipanti.Add (nomePartecipante);
    break;
    case 2:
        Console.WriteLine("Elenco partecipanti");
            foreach (string nome in nomi)
            {
                int numero = 1;
                Console.WriteLine($"{numero}++ . {nome}");
            }
    break;
    default:
        Console.WriteLine("Hai premuto il numero sbagliato");
    break;
}



