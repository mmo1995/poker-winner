using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;
using PokerWinnerEvaluator.CLI.Exceptions;

namespace PokerWinnerEvaluator.CLI.Application;

public class CardHandPairValidator: ICardHandPairValidator
{
    public void Validate(CardHand hand1, CardHand hand2)
    {
        ArgumentNullException.ThrowIfNull(hand1);
        ArgumentNullException.ThrowIfNull(hand2);

        var allCards = hand1.Cards.Concat(hand2.Cards).ToList();

        if (allCards.Count != allCards.Distinct().Count())
            throw new InvalidCardHandPairException();
    }
}