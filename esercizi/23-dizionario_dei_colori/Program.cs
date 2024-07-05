Dictionary<string,string> colori = new Dictionary<string, string>();
colori.Add("rosso", "FF0000");
colori.Add("verde", "00FF00");
colori.Add("blu", "0000FF");


foreach (KeyValuePair<string,string> colore in colori)
{
    Console.WriteLine("Il colore " + colore.Key + " ha il codice " + colore.Value + "."); //per concatenarela key e il valore
}


//si può anche aggiungere al dizionario con var:

var dizionario = new Dictionary<string, string>
{
    {"rosso", "FF0000"},
    {"verde", "00FF00"},
    {"blu", "0000FF"}
};

foreach (var elemento in dizionario)
{
    Console.WriteLine("Colore (= key):" + elemento.Key + ", ha il codice (= value):" + elemento.Value + "."); //per concatenarela key e il valore
}