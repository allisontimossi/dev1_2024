﻿using Spectre.Console; //dobbiamo mettercelo per forza

int scelta;
int scelta2;
string nome;
List<string> partecipanti = new List<string>();
partecipanti.Add ("Mattia");
partecipanti.Add ("Matteo");
partecipanti.Add ("Daniele");
partecipanti.Add ("Ginevra");
partecipanti.Add ("Serghej");
partecipanti.Add ("Silvano");
partecipanti.Add ("Allison");
partecipanti.Add ("Francesco");

List<string> selezionati = new List<string>();
selezionati.Add ("culetto");

bool continuePlaying = true;

while (continuePlaying)
{
var table = new Table();
table.AddColumn("Squadra 1");
table.AddColumn("Squadra 2");
foreach (string partecipante in partecipanti)
{
    table.AddRow(partecipante);
}

foreach (string selezionato in selezionati)
{
    table.AddRow(selezionato);
}
AnsiConsole.Write(table);

Console.Write("Vuoi aggiungere un partecipante nell'altra squadra? (s/n)");
string response = Console.ReadLine()!;

if (response == "s")
{
    Console.Write("Chi vuoi aggiungere?");
    nome = (Console.ReadLine());

    selezionati.Add (nome);
    partecipanti.Remove (nome);
}
else
{
    continuePlaying = false;
}
}