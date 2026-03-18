using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Contracts;

public interface IWinnerEvaluator
{
    public CardHand? GetWinner(CardHand hand1, CardHand hand2);
}