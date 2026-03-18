using Spectre.Console;

AnsiConsole.Clear();

AnsiConsole.Write(
    new FigletText("Poker Evaluator")
        .Centered()
        .Color(Color.Green));

AnsiConsole.MarkupLine("[bold white]Welcome to Poker Winner Evaluator![/]");
AnsiConsole.WriteLine();

bool exit = false;

while (!exit)
{
    var mode = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[yellow]Select Mode[/]")
            .PageSize(10)
            .AddChoices(new[] {
                "Generate Random Hand", 
                "Enter Manual Hand", 
                "Exit"
            }));

    switch (mode)
    {
        case "Generate Random Hand":
            AnsiConsole.MarkupLine("[blue]Random hand generation mode selected...[/]");
            AnsiConsole.WriteLine("Press any key to return to menu...");
            System.Console.ReadKey(true);
            break;
            
        case "Enter Manual Hand":
            AnsiConsole.MarkupLine("[blue]Manual hand entry mode selected...[/]");
            AnsiConsole.WriteLine("Press any key to return to menu...");
            System.Console.ReadKey(true);
            break;
            
        case "Exit":
            exit = true;
            AnsiConsole.MarkupLine("[red]Exiting... Goodbye![/]");
            break;
    }
    
    if (!exit)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(
            new FigletText("Poker Evaluator")
                .Centered()
                .Color(Color.Green));
    }
}