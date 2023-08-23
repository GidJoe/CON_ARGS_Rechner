using Spectre.Console;
using Rule = Spectre.Console.Rule;


namespace Rechner
{
    class Rechner
    {
        /* Thema:   Argumente aus der Kommandozeile auslesen
         *              
         *  Hier haben wir mal ein Beispiel für ein kleines Kommandozeilen-Tool.
         *  Beim Aufrufen einer Anwendung über die Kommandozeile können wir Argumente mitgeben.
         *  Die Argumente werden als Array von Strings an die Main-Methode übergeben.
         *  Mit dem args-Array können wir dann arbeiten in dem wir ganz simpel auf die einzelnen Elemente zugreifen.
         *  z.B. args[0] ist das erste Argument, args[1] das zweite Argument usw.
         * 
         * Hinweis: Die Ausgaben werden mit der Spectre Bibliothek formatiert.
         * 
         * von Marc W. It42+
         */
        
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                AnsiConsole.MarkupLine("[red]Ungültiges Befehlsformat. Verwenden Sie --help für Nutzungsinformationen.[/]");
                return;
            }

            if (args[0] == "--help")
            {
                ZeigeHilfe();
                return;
            }

            if (args.Length < 3)
            {
                AnsiConsole.MarkupLine("[red]Ungültiges Befehlsformat. Verwenden Sie --help für Nutzungsinformationen.[/]");
                return;
            }

            try
            {
                double num1 = Convert.ToDouble(args[1]);
                double num2 = Convert.ToDouble(args[2]);
                double ergebnis;

                switch (args[0])
                {
                    case "-sum":
                        ergebnis = Summe(num1, num2);
                        AnsiConsole.MarkupLine($"[green]Ergebnis: {ergebnis}[/]");
                        break;

                    case "-sub":
                        ergebnis = Subtrahieren(num1, num2);
                        AnsiConsole.MarkupLine($"[green]Ergebnis: {ergebnis}[/]");
                        break;

                    case "-mul":
                        ergebnis = Multiplizieren(num1, num2);
                        AnsiConsole.MarkupLine($"[green]Ergebnis: {ergebnis}[/]");
                        break;

                    case "-div":
                        if (num2 == 0)
                        {
                            AnsiConsole.MarkupLine("[red]Teilen durch Null ist nicht erlaubt![/]");
                            return;
                        }
                        ergebnis = Teilen(num1, num2);
                        AnsiConsole.MarkupLine($"[green]Ergebnis: {ergebnis}[/]");
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Ungültige Operation angegeben. Verwenden Sie --help für Nutzungsinformationen.[/]");
                        break;
                }
            }
            catch (FormatException)
            {
                AnsiConsole.MarkupLine("[red]Ungültige Nummern angegeben. Verwenden Sie --help für Nutzungsinformationen.[/]");
            }
        }

        static double Summe(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Subtrahieren(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiplizieren(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Teilen(double num1, double num2)
        {
            return num1 / num2;
        }

        static void ZeigeHilfe()
        {
            var regel = new Rule("[bold yellow]Rechner - Ein einfaches arithmetisches Kommandozeilen-Tool[/]").RuleStyle("green");
            AnsiConsole.Write(regel);

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold]Verwendung:[/]");

            
            AnsiConsole.Foreground = Color.Blue;
            AnsiConsole.WriteLine("  Rechner.exe [operation] [zahl1] [zahl2]");


            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold]Verfügbare Operationen:[/]");
            AnsiConsole.MarkupLine("  [cyan]-sum[/]   : Addiert zwei Zahlen.");
            AnsiConsole.MarkupLine("  [cyan]-sub[/]   : Subtrahiert die zweite Zahl von der ersten.");
            AnsiConsole.MarkupLine("  [cyan]-mul[/]   : Multipliziert zwei Zahlen.");
            AnsiConsole.MarkupLine("  [cyan]-div[/]   : Teilt die erste Zahl durch die zweite Zahl.");

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold]Beispiele:[/]");
            AnsiConsole.MarkupLine("  [blue]Rechner.exe -sum 4 5[/]");
            AnsiConsole.MarkupLine("  [blue]Rechner.exe -mul 3 7[/]");

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("Verwenden Sie [yellow]--help[/] um diese Nutzungsinformationen anzuzeigen.");
        }
    }
}
