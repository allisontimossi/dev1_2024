int scelta;
string nome;
List<string> partecipanti = new List<string>();
int opzione;

do
{
    Console.WriteLine("1. Inserisci partecipante ");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Esci");

    Console.Write("Scelta: "); //acquisizione della scelta dell'utente tra le tre opzioni possibili
    scelta = int.Parse(Console.ReadLine ());

    switch (scelta) 
    {
        case 1: //inserimento manuale in Lista del singolo partecipante
            Console.Write("Inserisci il nome del partecipante: ");
            nome = (Console.ReadLine());
            partecipanti.Add (nome);
        break;
        case 2:
            Console.WriteLine("Elenco partecipanti: "); // stampa dell'elenco dei partecipanti inseriti manualmente
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }

            do
            {
            Console.WriteLine("Come vuoi ordinare la lista?"); 
            Console.WriteLine("1. Crescente \n2. Decrescente");
            int opzione = Convert.ToInt32(Console.ReadLine());   

                    if (opzione == 1) //ordinamento crescente
                    {
                    partecipanti.Sort();
                        foreach (string partecipante in partecipanti)
                        {
                            Console.WriteLine(partecipante);
                        }
                    }
                    else if (opzione == 2)//ordinamento decrescente
                    {
                    partecipanti.Sort();
                    partecipanti.Reverse();
                        foreach (string partecipante in partecipanti)
                        {
                            Console.WriteLine(partecipante);
                        }
                    }
                    else
                    {
                            Console.WriteLine("Opzione non disponibile");
                    }
            }
            while (opzione > 2);

        break;
        case 3:
            Console.WriteLine("Arrivederci!");
        break;
        default:
            Console.WriteLine("Hai premuto il numero sbagliato");
        break;
    }
}
while (scelta != 3); //Esci = il ciclo continua finché non si preme 3

//ordinare la lista dei partecipanti in ordine alfabetico -> metodo "sort" che restituisce la lista 
//[es: partecipanti.Sort()]
//partecipanti.Sort()