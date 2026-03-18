namespace PokerWinnerEvaluator.CLI.Domain;

public class CardHand(IEnumerable<Card> cards) 
{
    public IEnumerable<Card> Cards { get; } = Validate(cards);
    
    public override string ToString() => $"CardHand: {string.Join(", ", Cards.Select(c => c.ToString()))}";
    
    private static List<Card> Validate(IEnumerable<Card> cards)
    {
        throw new NotImplementedException();
    }
}