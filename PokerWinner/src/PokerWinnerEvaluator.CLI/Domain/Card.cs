namespace PokerWinnerEvaluator.CLI.Domain;

public class Card(CardSuit suit, CardValue value)
{
    public CardSuit Suit { get; } = suit;
    public CardValue Value { get; } = value;
    
    public override string ToString() => $"Card: {Value} of {Suit}";
}