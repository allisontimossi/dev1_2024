﻿using Spectre.Console;

namespace Panels;

public static class Program
{
    public static void Main()
    {

        // Left adjusted panel with text
        AnsiConsole.Write(
            new Panel(new Text
            (
                
            ).LeftJustified())
                .Expand()
                .SquareBorder()
                .Header("[red]Turno[/]"));
    }

}