using Spectre.Console;

string path =@"file.txt";
string[] lines = File.ReadAllLines(path);
string [] partecipanti = new string [lines.Length]; 


int scelta;
int scelta2;
string nome;



    Console.Clear();

    scelta = AnsiConsole.Prompt(
    new SelectionPrompt<string>()

            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
            .AddChoices(new[] {
                "1. Inserisci partecipante/i","2. Visualizza partecipanti","3. Cerca un partecipante","4. Modifica il nome di un partecipante","5. Crea squadre", "6. Esci dal programma"
            }));

    switch (scelta) 
    {
        case "1. Inserisci partecipante/i": //inserimento manuale in Lista del singolo partecipante
            Console.Write("Inserisci il nome del partecipante: ");
 
            
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadKey(); 
            Console.Clear();
        break;

        case "2. Visualizza partecipanti":
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

        case "6. Esci dal programma":
            Console.WriteLine("Arrivederci!");
        break;

        case "3. Cerca un partecipante":
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
        case "4. Modifica il nome di un partecipante":
            Console.Write("4. Modifica il nome di un partecipante: ");
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

 //Esci = il ciclo continua finché non si preme 3

//ordinare la lista dei partecipanti in ordine alfabetico -> metodo "sort" che restituisce la lista 
//[es: partecipanti.Sort()]
//partecipanti.Sort()

//si può fare un menu con entrambe le opzioni, semplificando si può ordinare a prescindere e dare con if unica opzione Decrescente

//per cercare un partecipante specifico con metodo Lista.Contains (inserireNomeCheStiamoCercando)
//nomeLista.Remove(nomeDaRimuovere) possiamo dire di cercare il partecipante, possiamo dirgli di cancellarlo

//ci chiede il nome del partecipante da modificare +