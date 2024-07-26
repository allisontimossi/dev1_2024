﻿﻿﻿using Spectre.Console;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        int attempts = 0;
        int score = attempts*10;
        int round = 0;

        string PcCode = "";
        string ourCode = "";

        //creazione della palette colori con emoji
        string giallo = "" + Emoji.Known.YellowCircle;
        string viola = "" + Emoji.Known.PurpleCircle;
        string blu = "" + Emoji.Known.BlueCircle;
        string verde = "" + Emoji.Known.GreenCircle;
        string rosso = "" + Emoji.Known.RedCircle;
        string arancione = "" + Emoji.Known.OrangeCircle;
        string marrone = "" + Emoji.Known.BrownCircle;
        List<string> palette = new List<string> { giallo, viola, blu, verde, rosso, arancione, marrone };
        int colours = 0;
        List<string> chosenPalette = new List<string> {};
        
        string[] secretCode = new string[4];
        string[] guessCode = new string[4];

        string path = @"punteggi.csv";
        if (!File.Exists(path)) //rende persistenti i dati - se manca, il programma "cancella" il testo presente nel file
        {
            File.Create(path).Close();
        }
        
        DateTime now = DateTime.Now;
        int currentDate = now.Day;
        int currentMonth = now.Month;
        int currentHour = now.Hour;
        int currentMinute = now.Minute;

        //Menu iniziale
        var rule = new Rule($"Mastermind Game {giallo}{rosso}{verde}{blu}");
            rule.LeftJustified();
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine("");
        AnsiConsole.MarkupLine("[bold]Benvenuto a Mastermind![/]");
        AnsiConsole.MarkupLine("Io scelgo un codice segreto e tu provi a indovinarlo.\n");;
        var name = AnsiConsole.Prompt(new TextPrompt<string>("Contro chi sto giocando?"));
        AnsiConsole.WriteLine("");
        attempts = AnsiConsole.Prompt(new TextPrompt<int>("In quanti turni pensi di battermi?")); //scelta turni
        string[] dots = new string[attempts+1];
        string[] hints = new string[attempts+1];
        AnsiConsole.WriteLine("");
        colours = AnsiConsole.Prompt(new TextPrompt<int>("Quanti colori posso scegliere [1-7]"));
        chosenPalette = palette.GetRange(0, colours);

        //generazione del codice segreto
        for (int i = 0; i < secretCode.Length; i++)
        {
            Random code = new Random();
            secretCode[i] = chosenPalette[code.Next(0, colours)];
        }
        PcCode = string.Join(" ", secretCode);

        //tentativi
        while (attempts > 0)
        {
            for (int j = 0; j < guessCode.Length; j++)
            {

                AnsiConsole.WriteLine("\n\nScegli il tuo codice: ");
                guessCode[j] = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(chosenPalette.Count)
                    .AddChoices(chosenPalette));
                Console.Clear();
                ourCode = string.Join(" ", guessCode);
                Console.WriteLine($"\n{ourCode}");
                AnsiConsole.WriteLine($"\n{PcCode}"); 
            }

            dots[round] = ourCode;
            
            round++;
            attempts--;

            //logica dei suggerimenti
            int white = 0, black = 0;

            bool[] visited = new bool[4];
            bool[] guessVisited = new bool[4];

            //in caso colore-posizione corretti
            for (int i = 0; i < 4; i++)
            {
                if (guessCode[i] == secretCode[i])
                {
                    black++;
                    visited[i] = true;
                    guessVisited[i] = true;
                }
            }
            //in caso colore-NONposizione corretti
            for (int i = 0; i < 4; i++)
            {
                if (!guessVisited[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!visited[j] && guessCode[i] == secretCode[j])
                        {
                            white++;
                            visited[j] = true;
                            break;
                        }
                    }
                }
            }
            string hint = $"{Emoji.Known.BlackCircle}: {black} - {Emoji.Known.WhiteCircle}: {white}";
            hints[round - 1] = hint;
            
            //tabella suggerimenti
            var table = new Table();
            table.AddColumn("Round");
            table.AddColumn("Pedine");
            table.AddColumn("Suggerimenti");
            for (int i = 1; i <= round; i++)
            {
                table.AddRow(i.ToString(), dots[i-1], hints[i-1]);
            }
            
            Console.Clear();
            AnsiConsole.WriteLine("");
            AnsiConsole.Write(rule);
            AnsiConsole.Write(table);

            //fine del round
            if (ourCode == PcCode)
            {
                AnsiConsole.WriteLine($"\nHai vinto in {round} turni!");
                File.AppendAllText(path, $"\n{score} - {name} - {currentDate}/{currentMonth}-{currentHour}:{currentMinute}");

                AnsiConsole.WriteLine($"Vuoi giocare di nuovo?");
                var reStart = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                    .AddChoices(new[] {
                        "Sì","No"
                        }));
                switch (reStart)
                {
                    case "Sì":
                    attempts = AnsiConsole.Prompt(new TextPrompt<int>("In quanti turni pensi di battermi?"));
                    round = 0;
                    for (int i = 0; i < guessCode.Length; i++)
                    {
                        guessCode[i] = "";
                        secretCode[i] = "";
                        dots[i] = "";
                        hints[i] = "";
                    }
                    Console.Clear();
                    break;
                    case "No":
                    Console.WriteLine("Ciao ciao!");
                    attempts = 0;
                    break;
                }
            }
            else if (attempts == 0)
            {
                AnsiConsole.WriteLine("\nMi dispiace, ma hai perso!");
                File.AppendAllText(path, $"\n{score} - {name} - {currentDate}/{currentMonth}-{currentHour}:{currentMinute}");
                AnsiConsole.WriteLine($"Il codice era {PcCode}");
                //Menu restart
                AnsiConsole.WriteLine($"Vuoi giocare di nuovo?");
                var reStart = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more choice)[/]")
                    .AddChoices(new[] {
                        "Sì","No"
                        }));
                switch (reStart)
                {
                    case "Sì":
                    attempts = AnsiConsole.Prompt(new TextPrompt<int>("In quanti turni pensi di battermi?"));
                    round = 0;
                    for (int i = 0; i < guessCode.Length; i++)
                    {
                        guessCode[i] = "";
                        secretCode[i] = "";
                        dots[i] = "";
                        hints[i] = "";
                    }
                    Console.Clear();
                    break;
                    case "No":
                    Console.WriteLine("Ciao ciao!");
                    Console.Clear();
                    break;
                }
            }
            else if (attempts == 1)
            {
                AnsiConsole.WriteLine("\nTic-tac, hai ancora un tentativo.");
            }
            else
            {
                AnsiConsole.WriteLine($"\nRitenta, hai ancora {attempts} tentativi.");
            }

        }
    }
}