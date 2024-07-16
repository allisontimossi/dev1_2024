﻿using Spectre.Console;

bool continuaPartita = true;

string answer;
int turni = 0;
int puntiUmano = 100; // Entrambi i giocatori iniziano con 100 punti
int puntiPc = 100;

DateTime now = DateTime.Now;
int currentHour = now.Hour;
int currentMinute = now.Minute;

int partiteVinteUomo = 0;
int partiteVintePc = 0;

Random random = new Random();

string path = @"punteggi.txt";
string[] punteggi = File.ReadAllLines(path);

if (!File.Exists(path))
{
    File.Create(path).Close();
}

while (continuaPartita)
{
    while (puntiUmano > 0 && puntiPc > 0)

        // ogni turno, ciascuno lancia due dadi

        {
            Console.Clear();
            // Lancio dadi umano
            int dado1Umano = random.Next(1, 7);
            int dado2Umano = random.Next(1, 7);
            int sommaUmano = dado1Umano + dado2Umano;

            // Lancio dadi computer
            int dado1Pc = random.Next(1, 7);
            int dado2Pc = random.Next(1, 7);
            int sommaPc = dado1Pc + dado2Pc;

            var table = new Table();
                table.Border = TableBorder.Rounded;
                table.AddColumn(":game_die:");

                table.AddColumn(":man_dancing:");

                table.AddColumn(":desktop_computer:");

                table.AddRow("[bold] Lancio [/]", $"{dado1Umano} e {dado2Umano}", $"{dado1Pc} e {dado2Pc}");

                table.AddRow("[bold] Totale [/]", $"{sommaUmano}", $"{sommaPc}");

            AnsiConsole.Write(table);

            // Calcola la differenza e aggiorna i punteggi
            if (sommaUmano > sommaPc)
            {
                puntiPc -= sommaUmano - sommaPc;
                Console.WriteLine($"Il PC perde {sommaUmano - sommaPc} punti.");
            }
            else if (sommaPc > sommaUmano)
            {
                puntiUmano -= sommaPc - sommaUmano;
                Console.WriteLine($"L'umano perde {sommaPc - sommaUmano} punti.");
            }
            else
            {
                Console.WriteLine("Parità in questo turno.");
            }
            var rule = new Rule("Dice Game");
            rule.Justification = Justify.Left;

            AnsiConsole.Write(rule);
        AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[blue bold underline]Punteggi[/]")
            .CenterLabel()
            .AddItem("Uomo", puntiUmano, Color.Yellow)
            .AddItem("PC", puntiPc, Color.Green));

            var rule2 = new Rule();
            AnsiConsole.Write(rule2);

            AnsiConsole.MarkupLine($"Punti :man_dancing:: {puntiUmano}, Punti :desktop_computer:: {puntiPc}");
            Console.WriteLine("Premi un tasto per il prossimo turno...");
            Console.ReadKey();

            File.AppendAllText(path, $"Punteggi uomo: {puntiUmano}\n Punteggi macchina {puntiPc}\n");
            turni++;
        }


        if (puntiUmano <= 0)
        {
            AnsiConsole.Write(
            new FigletText($"Ho vinto in {turni} turni")
                .Centered()
                .Color(Color.Blue));
            partiteVinteUomo++;

        }
        else
        {
        AnsiConsole.Write(
            new FigletText($"Hai vinto in {turni} turni")
                .Centered()
                .Color(Color.Blue));
            partiteVintePc++;
        }

    Console.WriteLine("Vuoi ricominciare? (yes / no)");
    answer = Console.ReadKey();


        if (answer = "yes")
        {
            Console.WriteLine("Ricominciamo!");
            continuaPartita
            AnsiConsole.Clear();
        }
}
Console.WriteLine("Ciao ciao!");

File.AppendAllText(path, $"Fine partita: {currentHour}:{currentMinute};\n numero turni: {turni}\n");
File.AppendAllText(path, $"Partite vinte da te: {partiteVinteUomo}; Partite vinte dal Pc: {partiteVintePc}");
