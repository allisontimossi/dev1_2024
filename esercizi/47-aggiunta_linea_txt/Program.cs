string path =@"file.txt";
string[] lines = File.ReadAllLines(path);


lines[lines.Length] += "Ciao"; //aggiunge di una stringa in maniera selettiva
 //riassegna la variabile (tot righe -3 = prima riga)
File.WriteAllLines(path, lines);
