using Spectre.Console;

int attempts = 10;
int round = 1;
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

//generazione del codice segreto
for (int i = 0; i < secretCode.Length; i++) 
{
    Random code = new Random();
    secretCode [i] = palette[code.Next(0, 7)];
}
PcCode = string.Join(" ", secretCode);    
AnsiConsole.Write(PcCode);

Console.Clear();
var rule = new Rule("Mastermind Game");
    rule.LeftJustified();
    AnsiConsole.Write(rule);

while (attempts > 0)
{
    int white = 0;
    int black = 0;

            for (int j = 0; j < guessCode.Length; j++)
            {   
                AnsiConsole.WriteLine("\nScegli il tuo codice: ");
                guessCode [j] = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(palette.Count)

                    .AddChoices(palette));
                    Console.Clear();

                    ourCode = string.Join(" ", guessCode);
                    AnsiConsole.WriteLine($"\n{PcCode}"); //!!! DA TOGLIERE
                    AnsiConsole.WriteLine(ourCode);
            }

    round++;
    attempts--;

    for (int b = 0; b < 4; b++)                 
    {
        if (guessCode[b] == secretCode[b])
            {
                black++;
            }
        bool contains = guessCode.Contains(secretCode[b]);   
        if (contains == true && guessCode[b] != secretCode[b])
            {
                white++;
            }
        if (contains != true && guessCode[b] != secretCode[b])
            {
                Console.WriteLine("");
            }   
    }
        //hint
        Console.Write(""+ Emoji.Known.BlackCircle);
        Console.WriteLine($": {black}");
        Console.Write(""+ Emoji.Known.WhiteCircle);
        Console.Write($": {white}");

    //risultati del round
    if (ourCode == PcCode)
    {
        AnsiConsole.WriteLine("\nHai vinto!");
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

