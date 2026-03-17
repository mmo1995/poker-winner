namespace PokerWinnerEvaluator.CLI.Domain;

public class CardHand(IEnumerable<Card> cards) 
{
    public IEnumerable<Card> Cards { get; } = cards;
    
    public override string ToString() => $"CardHand: {string.Join(", ", Cards.Select(c => c.ToString()))}";
}