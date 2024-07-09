﻿﻿using Spectre.Console; //dobbiamo mettercelo per forza

/*
Console.Clear();
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
            .AddChoices(new[] {
                "1. Inserisci partecipante/i","2. Visualizza partecipanti","3. Cerca un partecipante","4. Modifica il nome di un partecipante","5. Esci dal programma"
            }));

//scelta 1
var favorites = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .PageSize(10)
        .Title("Chi partecipa alla [green] lezione[/]?")
        .MoreChoicesText("[grey](Move up and down to reveal more classmates)[/]")
        .InstructionsText("[grey](Press [blue]<space>[/] to toggle a choice, [green]<enter>[/] to accept)[/]") //schermata in piccolo di istruzioni
        .AddChoices(new[]
            {
                "Allison", "Mattia", "Ginevra", "Daniele", "Silvano", "Serghej", "Matteo",
            }));
*/

/*

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
*/
var table = new Table();
table.AddColumn("Squadra 1");
table.AddColumn("Squadra 2");
table.AddColumn("Squadra 3");

var partecipanti = new Dictionary<string, (string, string)> //!!! AGGIUNGERE A SCHEMA
{
{"Mario", ("Rossi", "1990")},
{"Luca", ("Verdi", "1980")},
{"Paolo", ("Bianchi", "1970")}
};

foreach (var partecipante in partecipanti)
{
    table.AddRow(partecipante.Key, partecipante.Value.Item1, partecipante.Value.Item2);
}

AnsiConsole.Write(table);