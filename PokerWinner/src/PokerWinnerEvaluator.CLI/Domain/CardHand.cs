namespace PokerWinnerEvaluator.CLI.Domain;

public class CardHand(List<Card> cards)
{
    public List<Card> Cards { get; } = cards;
    
    public override string ToString() => $"CardHand: {string.Join(", ", Cards.Select(c => c.ToString()))}";
}