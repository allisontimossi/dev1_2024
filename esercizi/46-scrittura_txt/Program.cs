string path =@"file.txt";
string[] lines = File.ReadAllLines(path); //array che contiene la lettura del file txt 
string[] nomi = new string[lines.Length]; //array di stringhe che ha grandezza quanto il primo array
//andiamo ad assegnare ad ogni linea del file di testo IL VALORE DElla riga corrispondente
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i]; 
}

string path2 =@"test2.txt";
File.Create(path2).Close(); //crea un file NON manualmente

bool noNomiConA = true;

foreach (string nome in nomi)
{
    if (nome.StartsWith("a")) //controlla se la stringa inizia con a 
    {
        File.AppendAllText(path2, nome + "\n");

        noNomiConA = false;
    }
}
if (noNomiConA)
{
    Console.WriteLine("non ci sono nomi con a");
}