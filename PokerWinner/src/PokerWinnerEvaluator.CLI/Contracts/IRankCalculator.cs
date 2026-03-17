using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Contracts;

public interface IRankCalculator
{
    public (HandRank Rank, List<CardValue> Values) CalculateRank(CardHand hand);
}