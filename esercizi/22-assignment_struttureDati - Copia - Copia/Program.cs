List<string> partecipanti = new List<string>();
int scelta;
int scelta2;
string nome;


do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Cerca un partecipante");
    Console.WriteLine("4. Modifica il nome di un partecipante");
    Console.WriteLine("5. Esci");

    Console.Write("Scelta: "); //acquisizione della scelta dell'utente tra le tre opzioni possibili
    scelta = int.Parse(Console.ReadLine ());

    switch (scelta) 
    {
        case 1: //inserimento manuale in Lista del singolo partecipante
            Console.Write("Inserisci il nome del partecipante: ");
            nome = (Console.ReadLine());
            partecipanti.Add (nome);
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadKey(); 
            Console.Clear();
        break;

        case 2:
            Console.WriteLine($"Elenco partecipanti: (totale: {partecipanti.Count})"); // stampa dell'elenco dei partecipanti inseriti manualmente
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }

            Console.WriteLine("Come vuoi ordinare la lista?"); 
            Console.WriteLine("1. Crescente \n2. Decrescente");
            scelta2 = Convert.ToInt32(Console.ReadLine());   

                    if (scelta2 == 1) //ordinamento crescente
                    {
                    partecipanti.Sort();
                        foreach (string partecipante in partecipanti)
                        {
                            Console.WriteLine(partecipante);
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                        }
                    }
                    else if (scelta2 == 2)//ordinamento decrescente
                    {
                    partecipanti.Sort();
                    partecipanti.Reverse();
                        foreach (string partecipante in partecipanti)
                        {
                            Console.WriteLine(partecipante);
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                        }
                    }
                    else
                    {
                            Console.WriteLine("Opzione non disponibile");
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                    }
        break;

        case 5:
            Console.WriteLine("Arrivederci!");
        break;

        case 3:
            Console.Write("Digita il nome di un partecipante: ");
            nome = Console.ReadLine();

            if (partecipanti.Contains(nome)) //per capire se partecipante è presente o no
            {
                Console.Write("Presente! Vuoi rimuovere questo partecipante? (Y): ");
                string scelta4 = Console.ReadLine().ToUpper();
                if (scelta4 == "Y")         //se presente lo rimuove
                {
                    partecipanti.Remove (nome);
                    Console.WriteLine("Premi un tasto per continuare..");
                    Console.ReadKey(); 
                    Console.Clear();
                }
            }
            else
            {
                Console.Write("Assente! Vuoi aggiungere questo partecipante? (Y): ");
                string scelta3 = Console.ReadLine().ToUpper();
                if (scelta3 == "Y")         //se assente lo aggiunge
                {
                    partecipanti.Add (nome);
                    Console.WriteLine("Premi un tasto per continuare..");
                    Console.ReadKey(); 
                    Console.Clear();
                }
            }  
        break;
        case 4:
            Console.Write("Digita il nome di un partecipante da modificare: ");
            nome = Console.ReadLine();

            if (partecipanti.Contains(nome)) //per capire se partecipante è presente o no
            {
                Console.Write("Nuovo nome: ");
                string nuovoNome = Console.ReadLine();
                int indice = partecipanti.IndexOf (nome);
                partecipanti [indice] = nuovoNome;
                Console.WriteLine("Il nome del partecipante è stato modificato.");
                Console.WriteLine("Premi un tasto per continuare..");
                Console.ReadKey(); 
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista.");
                Console.WriteLine("Premi un tasto per continuare..");
                Console.ReadKey(); 
                Console.Clear();
            }
        break;    
        default:
            Console.WriteLine("Scelta non valida");
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadKey(); 
            Console.Clear();
        break;
    }
}
while (scelta != 5); //Esci = il ciclo continua finché non si preme 3

//ordinare la lista dei partecipanti in ordine alfabetico -> metodo "sort" che restituisce la lista 
//[es: partecipanti.Sort()]
//partecipanti.Sort()

//si può fare un menu con entrambe le opzioni, semplificando si può ordinare a prescindere e dare con if unica opzione Decrescente

//per cercare un partecipante specifico con metodo Lista.Contains (inserireNomeCheStiamoCercando)
//nomeLista.Remove(nomeDaRimuovere) possiamo dire di cercare il partecipante, possiamo dirgli di cancellarlo

//ci chiede il nome del partecipante da modificare +