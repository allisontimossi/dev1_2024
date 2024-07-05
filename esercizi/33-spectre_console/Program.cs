using Spectre.Console;
AnsiConsole.Clear();     

AnsiConsole.Markup("[bold mediumspringgreen]Hello[/] [117]World![/]\n");

var continua = AnsiConsole.Confirm("Vuoi continuare?");

var table = new Table();
table.AddColumn("Nome corso");
table.AddColumn("Anno");
table.AddRow("Corso di informatica", "2024");
AnsiConsole.Render(table);


var rule = new Rule("[red]Hello[/]");
rule.Justification = Justify.Left; //Justify.Center, Justify.Right // Per centrarlo, non digitare nulla
AnsiConsole.Write(rule);

var nome = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il tuo nome: "));

var panel = new Panel("Questo è un testo all'interno di un pannelloooo");
panel.Border = BoxBorder.Rounded;
AnsiConsole.Render(panel);

var baChart = new BarChart();
    .Width(60)
    .Label("[green bold underline]Number of fruits[/]")
    .CenterLabel()
    .AddItem("Apple", 12, Color.Yellow)
    .AddItem("Orange", 53, Color.Green)
    .AddItem("Banana", 33, Color.Red)