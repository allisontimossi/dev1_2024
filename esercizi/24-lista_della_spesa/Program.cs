Dictionary<string,int> listaSpesa = new Dictionary<string, int>();
listaSpesa.Add("pane", 1);
listaSpesa.Add("latte", 2);

listaSpesa["uova"] = 12; //modo alternativo di aggiungere al dizionario
listaSpesa["pane"] = listaSpesa["pane"] +1; //per incrementare il Value

foreach (KeyValuePair<string,int> articolo in listaSpesa)
{
    Console.WriteLine($"Articolo: {articolo.Key} - Quantità: {articolo.Value}"); //per concatenarela key e il valore
}