string path =@"file.txt";
string[] lines = File.ReadAllLines(path); //classe file 
foreach (string line in lines)
{
    Console.WriteLine(line);   
}