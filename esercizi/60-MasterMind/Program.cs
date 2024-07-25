﻿using Spectre.Console;


int attempts = 10;
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
string marrone = ""+ Emoji.Known.BrownCircle;
List<string> palette = new List<string>{giallo, viola, blu, verde, rosso, arancione, marrone};

string [] secretCode = new string [4];
string [] guessCode = new string [4];   

string [] dots = new string [10];
string [] hints = new string [10];

//generazione del codice segreto
for (int i = 0; i < secretCode.Length; i++) 
{
    Random code = new Random();
    secretCode [i] = palette[code.Next(0, 7)];
}
PcCode = string.Join(" ", secretCode);    

//titolo
var rule = new Rule($"Mastermind Game {giallo}{rosso}{verde}{blu}");
    rule.LeftJustified();
    AnsiConsole.Write(rule);

//tentativi
while (attempts > 0)
{
    //metterci il titolo
    for (int j = 0; j < guessCode.Length; j++)
    {   
        AnsiConsole.WriteLine("\nScegli il tuo codice: ");
        guessCode [j] = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(palette.Count)

            .AddChoices(palette));

            Console.Clear();
            ourCode = string.Join(" ", guessCode);
            //AnsiConsole.WriteLine($"\n{PcCode}"); //!!! DA TOGLIERE
            
            AnsiConsole.WriteLine(ourCode);
    }
    dots[round] = ourCode;
    
    round++;
    attempts--;

//hint
    int white = 0, black = 0;
    
    bool[] visited = new bool[4];
    bool[] guessVisited = new bool[4];

    for (int i = 0; i < 4; i++)                 
    {
        if (guessCode[i] == secretCode[i])
        {
            black++;
            visited [i] = true;
            guessVisited [i] = true;
        }  
    }
    for (int i = 0; i < 4; i++)
    {
        if (!guessVisited[i])
        {
            for (int j = 0; j < 4; j++)
            {
                if (!visited[j] && guessCode [i] == secretCode [j])
                {
                    white++;
                    visited [j] = true;
                    break;
                }
            }
        }
    } 
    string hint = $"{Emoji.Known.BlackCircle}: {black} - {Emoji.Known.WhiteCircle}: {white}";      
    hints[round - 1] = hint;
    //tabella

    var table = new Table();
    table.AddColumn ("Round");
    table.AddColumn ("Pedine");
    table.AddColumn ("Suggerimenti");
    for (int i = 0; i <= dots.Length; i++)
    {
        table.AddRow(i + 1, dots[i], hints[i]); 
    }
    AnsiConsole.Write(table);

    //risultati del round
    if (ourCode == PcCode)
    {
        AnsiConsole.WriteLine($"\nHai vinto in {round} turni!");
        break;
    }
    else if (attempts == 0)
    {
        AnsiConsole.WriteLine("\nMi dispiace, ma hai perso!");
        AnsiConsole.WriteLine($"Il codice era {PcCode}");
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