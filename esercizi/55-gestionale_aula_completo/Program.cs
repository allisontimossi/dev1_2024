using Spectre.Console; 

List<string> aula = new List<string>(File.ReadAllLines(@"Partecipanti.txt")); //!!!collegamento tra file txt e una lista
string path = @"Partecipanti.txt";

string partecipante;
string scelta;
string nome;

if (!File.Exists(path))
{
    File.Create(path).Close();
}

List<string> squadra1 = [];
List<string> squadra2 = [];

Random random = new Random ();
bool primasquadra = true;

do
{

    scelta = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
            .AddChoices(new[] {
                "1. Inserisci partecipante/i","2. Visualizza partecipanti","3. Cerca un partecipante","4. Modifica il nome di un partecipante","5. Crea squadre", "6. Esci dal programma"
                })); 
    switch (scelta)
        {
            case "1. Inserisci partecipante/i":
                Console.Write("Inserisci il nome del partecipante: ");
                partecipante = (Console.ReadLine());
                aula.Add (partecipante);



                if (File.ReadAllLines(path).Contains(partecipante))
                {
                    Console.WriteLine ("Nome già presente");
                }
                else
                {
                    File.AppendAllText(path, $"{partecipante}\n");
                    Console.WriteLine ("Il nome è stato aggiunto");
                }          
            break;
            case "2. Visualizza partecipanti":
                Console.WriteLine($"Elenco partecipanti: (totale: {aula.Count})");
                    foreach (string line in aula)
                        {
                            Console.WriteLine(line);   
                        }
                Console.WriteLine("Come vuoi ordinare la lista?");
                var scelta2 = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                    .AddChoices(new[] {
                        "Crescente","Decrescente"
                        }));
                switch (scelta2)
                {
                    case "Crescente":
                    aula.Sort();
                        foreach (string nom in aula)
                        {
                            Console.WriteLine(nom);
                        }   
                    break;
                    case "Decrescente":
                    aula.Sort();
                    aula.Reverse();
                        foreach (string nom in aula)
                        {
                            Console.WriteLine(nom);
                        }
                    break;
                }
                Console.WriteLine("Premi un tasto per continuare..");
                Console.ReadKey(); 
                Console.Clear();
            break;
            case "3. Cerca un partecipante":
                Console.Write("Digita il nome di un partecipante: ");
                nome = Console.ReadLine();

                if (aula.Contains(nome)) //per capire se partecipante è presente o no
                {
                    Console.WriteLine("Presente! Vuoi rimuovere questo partecipante? ");
                    var scelta3 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                        .AddChoices(new[] {
                            "Sì","No"
                            }));
                    switch (scelta3)
                    {
                        case "Sì":
                            aula.Remove (nome);
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                        break;
                        case "No":
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();                       
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Assente! Vuoi aggiungere questo partecipante?");
                    var scelta4 = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                        .AddChoices(new[] {
                            "Sì","No"
                            }));
                    switch (scelta4)
                    {
                        case "Sì":
                            aula.Add (nome);
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                        break;
                        case "No":
                        break;
                    }
                }
            break;
            case "4. Modifica il nome di un partecipante":
                Console.Write("Digita il nome di un partecipante da modificare: ");
                nome = Console.ReadLine();

                if (aula.Contains(nome)) //per capire se partecipante è presente o no
                    {
                        Console.Write("Nuovo nome: ");
                        string nuovoNome = Console.ReadLine();
                        int indice = aula.IndexOf (nome);
                        aula [indice] = nuovoNome;
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
            case "5. Crea squadre":
                Console.WriteLine("Ecco le due squadre sorteggiate:");
                while (aula.Count > 0)
                {
                    int estrazione = random.Next(aula.Count);
                    if (primasquadra)
                    {
                        squadra1.Add(aula[estrazione]);
                        primasquadra = false;
                    }
                    else
                    {
                        squadra2.Add(aula[estrazione]);
                        primasquadra = true;
                    }
                    aula.RemoveAt(estrazione);
                }

                var table = new Table();
                    table.AddColumn("Squadra 1");
                    table.AddColumn("Squadra 2");
                for (int i = 0; i < aula.Count; i++)
                    {
                        table.AddRow(squadra1[i], squadra2[i]);
                    }
                AnsiConsole.Write(table);

            break;
            case "6. Esci dal programma":
                Console.WriteLine("Arrivederci!");
            break;
        }
    }
while (scelta != "6. Esci dal programma");