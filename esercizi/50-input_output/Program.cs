string path =@"file.txt";
string[] lines = File.ReadAllLines(path);
string [] nomi= new string [lines.Length];
for (int i = 0; i < nomi.Length; i++)  
{
    nomi [i] = lines[i];
} 

Random random = new Random();
int index = random.Next(nomi.Length);
Console.WriteLine ($"Il nome estratto e che verrà spostato è: {nomi[index]}");

string path2 = @"file2.txt";

if (!File.Exists(path2))
{
    File.Create(path2).Close(); //crea un nuovo file
}

File.AppendAllText(path2,  nomi[index] + "\n"); //il nome estratto viene scritto nel nuovo file 