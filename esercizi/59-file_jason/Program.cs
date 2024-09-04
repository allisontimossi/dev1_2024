using Newtonsoft.Json;

/*
string path = @"test.json";
string json = File.ReadAllText(path);  //legge il file
//Console.WriteLine(json);             //stampa il file così com'è (brutto), meglio con txt

// senza array
/*
dynamic obj = JsonConvert.DeserializeObject(json)!;
Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} età: {obj.età}"); //lettura lineare
Console.WriteLine($"via: {obj.indirizzo.via} città: {obj.indirizzo.città}"); //lettura multilivello per lettura nodi


//array 
dynamic obj = JsonConvert.DeserializeObject(json)!;
string path2 = @"test.csv";
File.Create(path2).Close();

File.AppendAllText(path2, "nome,\tcognome,\tetà,\tvia,\tcittà\n");
for (int i = 0; i < obj.Count; i ++) 
{
    File.AppendAllText(path2, $"{obj[i].nome},\t{obj[i].cognome},\t{obj[i].età},\t{obj[i].indirizzo.via},\t{obj[i].indirizzo.città}\n");
}
*/

//PROGRAMMA che legge elenco di file json dentro a una cartella, permette di selezionarne uno e visualizzarne il contenuto
string Cartella = @".\Json-Folder";
string [] files = Directory.GetFiles(Cartella, "*.json"); //legge tutti i file .json

if (files.Length == 0) //se non ci sono file all'interno 
{
    Console.WriteLine("non ci sono file json nella cartella");
    return; //esce dal programma
}

Console.WriteLine("Elenco dei file json");
for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine($"{i+1}. {Path.GetFileName(files[i])}");
}

Console.WriteLine ("Quale file vuoi leggere? ");
if (int.TryParse(Console.ReadLine(), out int scelta) && scelta > 0 && scelta <= files.Length)
{
    string fileScelto = files[scelta -1];
    string json = File.ReadAllText(fileScelto);
    dynamic obj = JsonConvert.DeserializeObject(json);
    Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
}
else
{
    Console.WriteLine("Scelta non valida");
}