﻿using Spectre.Console; //dobbiamo mettercelo per forza


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

List<string> aula = new List<string>();
new SelectionPrompt<string>()
        
                    .PageSize(aula.Count)
                    .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                    .AddChoices(aula);

