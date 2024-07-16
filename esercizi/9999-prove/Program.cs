using Spectre.Console; //dobbiamo mettercelo per forza
List<string> nomi = new List<string>();
nomi.Add ("Mattia");
nomi.Add ("Matteo");
nomi.Add ("Daniele");
nomi.Add ("Ginevra");
nomi.Add ("Serghej");
nomi.Add ("Allison");


Console.Clear();
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        
            .PageSize(nomi.Count)
            .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
            .AddChoices(nomi));
