using Newtonsoft.Json;

string path = @"test.json";
string json = File.ReadAllText(path);  //legge il file
//Console.WriteLine(json);             //stampa il file così com'è (brutto), meglio con txt

// senza array
/*
dynamic obj = JsonConvert.DeserializeObject(json)!;
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} età: {obj.età}"); //lettura lineare
Console.WriteLine($"via: {obj.indirizzo.via} città: {obj.indirizzo.città}"); //lettura multilivello per lettura nodi
*/

//array 
dynamic obj = JsonConvert.DeserializeObject(json)!;
string path2 = @"test.csv";
File.Create(path2).Close();

File.AppendAllText(path2, "nome,\tcognome,\tetà,\tvia,\tcittà\n");
for (int i = 0; i < obj.Count; i ++) 
{
    File.AppendAllText(path2, $"{obj[i].nome},\t{obj[i].cognome},\t{obj[i].età},\t{obj[i].indirizzo.via},\t{obj[i].indirizzo.città}\n");
}
