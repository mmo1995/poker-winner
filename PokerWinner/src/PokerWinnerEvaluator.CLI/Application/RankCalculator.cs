using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Application;

public class RankCalculator: IRankCalculator
{
    public (HandRank Rank, List<CardValue> Values) CalculateRank(CardHand hand)
    {
        var sortedValues = hand.Cards.Select(card => card.Value).OrderByDescending(v => v).ToList();
        var suitCount = hand.Cards.Select(card => card.Suit).Distinct().Count();
        
        if(IsStraightRank(sortedValues) && suitCount == 1)
            return (HandRank.StraightFlush, sortedValues);
        
        if (GetSameValuesCount(sortedValues) == 4)
            return (HandRank.FourOfAKind, sortedValues);
        
        return (HandRank.HighCard, sortedValues);
    }

    private static bool IsStraightRank(List<CardValue> sortedValues)
    {
        for (var i = 0; i < sortedValues.Count - 1; i++)
        {
            if (sortedValues[i] - sortedValues[i + 1] != 1)
                return false;
        }
        return true;
    }
    private static int GetSameValuesCount(List<CardValue> values) => values.GroupBy(v => v).Max(g => g.Count());
}