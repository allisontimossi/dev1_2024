string path =@"file.txt";
string[] lines = File.ReadAllLines(path); //array che contiene la lettura del file txt 
string[] nomi = new string[lines.Length]; //array di stringhe che ha grandezza quanto il primo array
//andiamo ad assegnare ad ogni linea del file di testo IL VALORE DElla riga corrispondente
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i]; 
}
bool noMonello = true;

foreach (string nome in nomi)
{
    if (nome.StartsWith("a").ToUpper()); //controlla se la stringa inizia con a 
    {
        Console.WriteLine (nome);
        noMonello = false;
    }
}
if (noMonello)
{
    Console.WriteLine("non ci sono monelli");
}