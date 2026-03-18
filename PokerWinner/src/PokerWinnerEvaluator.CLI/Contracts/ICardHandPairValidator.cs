using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Contracts;

public interface ICardHandPairValidator
{
    void Validate(CardHand hand1, CardHand hand2);
}