using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Application;

public class RankCalculator: IRankCalculator
{
    public (HandRank Rank, List<CardValue> Values) CalculateRank(CardHand hand)
    {
        throw new NotImplementedException();
    }
}