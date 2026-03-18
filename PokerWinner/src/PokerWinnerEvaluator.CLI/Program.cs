using Microsoft.Extensions.DependencyInjection;
using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICardHandPairValidator, CardHandPairValidator>()
    .AddSingleton<IRankCalculator, RankCalculator>()
    .AddSingleton<IWinnerEvaluator, WinnerEvaluator>()
    .BuildServiceProvider();

var winnerEvaluator = serviceProvider.GetRequiredService<IWinnerEvaluator>();
var rankCalculator = serviceProvider.GetRequiredService<IRankCalculator>();

Console.WriteLine(new string('=', 50));
Console.WriteLine("          POKER WINNER EVALUATOR                  ");
Console.WriteLine(new string('=', 50));
Console.WriteLine();

// Scenario 1: High Card vs Pair
var highCard = new CardHand([
    new Card(CardSuit.S, CardValue.A), new Card(CardSuit.D, CardValue.K), new Card(CardSuit.C, CardValue.Two), 
    new Card(CardSuit.H, CardValue.Five), new Card(CardSuit.S, CardValue.Nine)
]);
var (rank, _)= rankCalculator.CalculateRank(highCard);
var pair = new CardHand([
    new Card(CardSuit.S, CardValue.Two), new Card(CardSuit.D, CardValue.Two), new Card(CardSuit.C, CardValue.Three), 
    new Card(CardSuit.H, CardValue.Four), new Card(CardSuit.S, CardValue.Five)
]);
EvaluateAndPrint("High Card (A) vs Pair of Twos", highCard, pair);

// Scenario 2: Flush vs Straight
var flush = new CardHand([
    new Card(CardSuit.H, CardValue.Two), new Card(CardSuit.H, CardValue.Five), new Card(CardSuit.H, CardValue.Eight), 
    new Card(CardSuit.H, CardValue.J), new Card(CardSuit.H, CardValue.K)
]);
var straight = new CardHand([
    new Card(CardSuit.S, CardValue.Five), new Card(CardSuit.D, CardValue.Six), new Card(CardSuit.C, CardValue.Seven), 
    new Card(CardSuit.S, CardValue.Eight), new Card(CardSuit.H, CardValue.Nine)
]);
EvaluateAndPrint("Flush vs Straight", flush, straight);

// Scenario 3: Full House vs Three of a Kind
var fullHouse = new CardHand([
    new Card(CardSuit.S, CardValue.Ten), new Card(CardSuit.D, CardValue.Ten), new Card(CardSuit.C, CardValue.Ten), 
    new Card(CardSuit.H, CardValue.Two), new Card(CardSuit.S, CardValue.Two)
]);
var threeOfAKind = new CardHand([
    new Card(CardSuit.S, CardValue.A), new Card(CardSuit.D, CardValue.A), new Card(CardSuit.C, CardValue.A), 
    new Card(CardSuit.H, CardValue.K), new Card(CardSuit.S, CardValue.Q)
]);
EvaluateAndPrint("Full House vs Three of a Kind", fullHouse, threeOfAKind);

// Scenario 4: Draw
var handA = new CardHand([
    new Card(CardSuit.S, CardValue.A), new Card(CardSuit.D, CardValue.K), new Card(CardSuit.C, CardValue.Q), 
    new Card(CardSuit.H, CardValue.J), new Card(CardSuit.S, CardValue.Ten)
]);
var handB = new CardHand([
    new Card(CardSuit.H, CardValue.A), new Card(CardSuit.C, CardValue.K), new Card(CardSuit.S, CardValue.Q), 
    new Card(CardSuit.D, CardValue.J), new Card(CardSuit.H, CardValue.Ten)
]);
EvaluateAndPrint("Identical Straights (Draw)", handA, handB);

Console.WriteLine(new string('=', 50));
Console.WriteLine("             END OF EVALUATION                    ");
Console.WriteLine(new string('=', 50));

void EvaluateAndPrint(string description, CardHand h1, CardHand h2)
{
    Console.WriteLine($"Scenario: {description}");
    Console.WriteLine($"Hand 1: {h1}");
    Console.WriteLine($"Hand 2: {h2}");

    var winner = winnerEvaluator.GetWinner(h1, h2);

    if (winner == null)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("RESULT: It's a draw (Split Pot)!");
    }
    else if (winner == h1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("RESULT: Hand 1 wins!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("RESULT: Hand 2 wins!");
    }

    Console.ResetColor();
    Console.WriteLine(new string('-', 50));
    Console.WriteLine();
}

