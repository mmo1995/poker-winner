using Spectre.Console;
using PokerWinnerEvaluator.CLI.Domain;
using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Contracts;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var rankCalculator = new RankCalculator();
var validator = new CardHandPairValidator();
var evaluator = new WinnerEvaluator(rankCalculator, validator);

AnsiConsole.Clear();

AnsiConsole.Write(
    new FigletText("Poker Evaluator")
        .Centered()
        .Color(Color.Green));

AnsiConsole.MarkupLine("[bold white]Welcome to Poker Winner Evaluator![/]");
AnsiConsole.WriteLine();

var exit = false;

while (!exit)
{
    var mode = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[yellow]Select Mode[/]")
            .PageSize(10)
            .AddChoices("Generate Random Hand", "Enter Manual Hand", "Exit"));

    switch (mode)
    {
        case "Generate Random Hand":
            AnsiConsole.MarkupLine("[blue]Random hand generation mode selected...[/]");
            
            var allCardsRandom = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    allCardsRandom.Add(new Card(suit, value));
                }
            }

            var random = new Random();
            var shuffledCards = allCardsRandom.OrderBy(_ => random.Next()).ToList();
            
            var hand1Random = new CardHand(shuffledCards.Take(5));
            var hand2Random = new CardHand(shuffledCards.Skip(5).Take(5));

            DisplayEvaluation(hand1Random, hand2Random, rankCalculator, evaluator);
            
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Press any key to return to menu...");
            System.Console.ReadKey(true);
            break;
            
        case "Enter Manual Hand":
            AnsiConsole.MarkupLine("[blue]Manual hand entry mode selected...[/]");
            
            var allCards = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    allCards.Add(new Card(suit, value));
                }
            }

            var selectedCards = new List<Card>();

            AnsiConsole.MarkupLine("[yellow]Enter cards for Hand 1 (5 cards):[/]");
            var hand1Cards = PickCards(allCards, selectedCards, 5);
            var hand1 = new CardHand(hand1Cards);
            
            AnsiConsole.MarkupLine("[yellow]Enter cards for Hand 2 (5 cards):[/]");
            var hand2Cards = PickCards(allCards, selectedCards, 5);
            var hand2 = new CardHand(hand2Cards);

            AnsiConsole.Clear();
            DisplayEvaluation(hand1, hand2, rankCalculator, evaluator);

            AnsiConsole.WriteLine();
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

static List<Card> PickCards(List<Card> allCards, List<Card> selectedCards, int count)
{
    var picked = new List<Card>();
    for (int i = 0; i < count; i++)
    {
        var prompt = new SelectionPrompt<Card>()
            .Title($"Select Card {i + 1} of {count}")
            .PageSize(15)
            .UseConverter(c => FormatCard(c, selectedCards.Contains(c)));

        foreach (var card in allCards)
        {
            if (selectedCards.Contains(card))
            {
            }
            else
            {
                prompt.AddChoice(card);
            }
        }

        var selectedCard = AnsiConsole.Prompt(prompt);
        picked.Add(selectedCard);
        selectedCards.Add(selectedCard);
        
        AnsiConsole.MarkupLine($"[green]Selected:[/] {FormatCard(selectedCard)}");
    }
    return picked;
}

static string FormatCard(Card card, bool isDisabled = false)
{
    var suitStr = card.Suit switch
    {
        CardSuit.H => "♥H",
        CardSuit.D => "♦D",
        CardSuit.C => "♣C",
        CardSuit.S => "♠S",
        _ => card.Suit.ToString()
    };

    var valueStr = card.Value switch
    {
        CardValue.Two => "2",
        CardValue.Three => "3",
        CardValue.Four => "4",
        CardValue.Five => "5",
        CardValue.Six => "6",
        CardValue.Seven => "7",
        CardValue.Eight => "8",
        CardValue.Nine => "9",
        CardValue.Ten => "10",
        CardValue.J => "J",
        CardValue.Q => "Q",
        CardValue.K => "K",
        CardValue.A => "A",
        _ => card.Value.ToString()
    };

    if (isDisabled)
    {
        return $"[grey]{valueStr}{suitStr}[/]";
    }

    return $"{valueStr}{suitStr}";
}

static void DisplayEvaluation(CardHand hand1, CardHand hand2, IRankCalculator rankCalculator, IWinnerEvaluator evaluator)
{
    var (hand1Rank, _) = rankCalculator.CalculateRank(hand1);
    var (hand2Rank, _) = rankCalculator.CalculateRank(hand2);
    var winner = evaluator.GetWinner(hand1, hand2);

    AnsiConsole.Write(new Rule("[green]Evaluation Results[/]"));
    
    var table = new Table().Border(TableBorder.Rounded);
    table.AddColumn("[bold blue]Hand 1[/]");
    table.AddColumn("[bold red]Hand 2[/]");
    
    table.AddRow(
        string.Join(", ", hand1.Cards.Select(c => FormatCard(c))),
        string.Join(", ", hand2.Cards.Select(c => FormatCard(c)))
    );
    
    table.AddRow(
        $"[bold blue]Rank:[/] {hand1Rank.ToString()}",
        $"[bold red]Rank:[/] {hand2Rank.ToString()}"
    );

    AnsiConsole.Write(table);

    if (winner == null)
    {
        AnsiConsole.MarkupLine("[bold yellow]It's a TIE![/]");
    }
    else if (ReferenceEquals(winner, hand1))
    {
        AnsiConsole.MarkupLine("[bold blue]Hand 1 WINS![/]");
    }
    else
    {
        AnsiConsole.MarkupLine("[bold red]Hand 2 WINS![/]");
    }
    
    AnsiConsole.Write(new Rule());
}