﻿using Spectre.Console; //dobbiamo mettercelo per forza
int choice;
int scelta2;
string nome;
List<string> classe = [];

List<string> squadra1 = [];
List<string> squadra2 = [];


Random random = new Random ();
bool primasquadra = true;
do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Cerca un partecipante");
    Console.WriteLine("4. Modifica il nome di un partecipante");
    Console.WriteLine("5. Esci");

    Console.Write("Scelta: ");

    Console.Write("Scelta: "); 
    choice = int.Parse(Console.ReadLine ());
    switch (choice) 
    {
        case 1: //inserimento manuale in Lista del singolo partecipante
            Console.Write("Inserisci il nome del partecipante: ");
            nome = (Console.ReadLine());
            classe.Add (nome);
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadKey(); 
            Console.Clear();
        break;

        case 2:
            Console.WriteLine($"Elenco partecipanti: (totale: {classe.Count})"); // stampa dell'elenco dei partecipanti inseriti manualmente
            foreach (string partecipante in classe)
            {
                Console.WriteLine(partecipante);
            }

            Console.WriteLine("Come vuoi ordinare la lista?"); 
            Console.WriteLine("1. Crescente \n2. Decrescente");
            scelta2 = Convert.ToInt32(Console.ReadLine());   

                    if (scelta2 == 1) //ordinamento crescente
                    {
                    classe.Sort();
                        foreach (string partecipante in classe)
                        {
                            Console.WriteLine(partecipante);
                            Console.WriteLine("Premi un tasto per continuare..");
                            Console.ReadKey(); 
                            Console.Clear();
                        }
                    }
                    else if (scelta2 == 2)//ordinamento decrescente
                    {
                    classe.Sort();
                    classe.Reverse();
                        foreach (string partecipante in classe)
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

            while (classe.Count > 0)
                {
                int estrazione = random.Next(classe.Count);
                if (primasquadra)
                {
                    squadra1.Add (classe[estrazione]);
                    primasquadra = false;
                }
                else
                {
                    squadra2.Add (classe[estrazione]);
                    primasquadra = true;
                }
                classe.RemoveAt (estrazione);  
                }

            var table = new Table();
            table.AddColumn("Squadra 1");
            
            foreach (string partecipante in squadra1)
            {
                table.AddRow(partecipante);
            }
            AnsiConsole.Write(table);

            var table2 = new Table();
            table2.AddColumn("Squadra 2");
            foreach (string partecipante in squadra2)
            {
                table2.AddRow(partecipante);
            }
            AnsiConsole.Write(table2);
        break;

        case 3:
            Console.Write("Digita il nome di un partecipante: ");
            nome = Console.ReadLine();

            if (classe.Contains(nome)) //per capire se partecipante è presente o no
            {
                Console.Write("Presente! Vuoi rimuovere questo partecipante? (Y): ");
                string scelta4 = Console.ReadLine().ToUpper();
                if (scelta4 == "Y")         //se presente lo rimuove
                {
                    classe.Remove (nome);
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
                    classe.Add (nome);
                    Console.WriteLine("Premi un tasto per continuare..");
                    Console.ReadKey(); 
                    Console.Clear();
                }
            }  
        break;
        case 4:
            Console.Write("Digita il nome di un partecipante da modificare: ");
            nome = Console.ReadLine();

            if (classe.Contains(nome)) //per capire se partecipante è presente o no
            {
                Console.Write("Nuovo nome: ");
                string nuovoNome = Console.ReadLine();
                int indice = classe.IndexOf (nome);
                classe [indice] = nuovoNome;
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
        case 6:
            Console.WriteLine("Arrivederci!");
        break;    
        default:
            Console.WriteLine("Scelta non valida");
            Console.WriteLine("Premi un tasto per continuare..");
            Console.ReadKey(); 
            Console.Clear();
        break;
    }
}
while (choice != 6);

    
