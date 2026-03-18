using PokerWinnerEvaluator.CLI.Exceptions;

namespace PokerWinnerEvaluator.CLI.Domain;

public class CardHand(IEnumerable<Card> cards) 
{
    public IEnumerable<Card> Cards { get; } = Validate(cards);
    
    public override string ToString() => $"CardHand: {string.Join(", ", Cards.Select(c => c.ToString()))}";
    
    private static List<Card> Validate(IEnumerable<Card> cards)
    {
        var cardList = cards.ToList();

        if (cardList.Count != 5)
            throw new InvalidCardHandException("A poker hand must contain exactly 5 cards.");

        return cardList.Distinct().Count() != cardList.Count 
            ? throw new InvalidCardHandException("A poker hand cannot contain the same card twice.")
            : cardList;
    }
}