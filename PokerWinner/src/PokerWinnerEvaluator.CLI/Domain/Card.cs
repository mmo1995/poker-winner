namespace PokerWinnerEvaluator.CLI.Domain;

public class Card(CardSuit suit, CardValue value) : IEquatable<Card>
{
    public CardSuit Suit { get; } = suit;
    public CardValue Value { get; } = value;
    
    public override string ToString() => $"Card: {Value} of {Suit}";
    
    public bool Equals(Card? other)
        => other is not null && Suit == other.Suit && Value == other.Value;

    public override bool Equals(object? obj)
        => obj is Card other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(Suit, Value);

    public static bool operator ==(Card? left, Card? right)
        => EqualityComparer<Card>.Default.Equals(left, right);

    public static bool operator !=(Card? left, Card? right)
        => !(left == right);
}