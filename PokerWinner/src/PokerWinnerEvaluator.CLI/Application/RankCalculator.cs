using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Application;

public class RankCalculator: IRankCalculator
{
    public (HandRank Rank, List<CardValue> Values) CalculateRank(CardHand hand)
    {
        var sortedValues = hand.Cards.Select(card => card.Value).OrderByDescending(v => v).ToList();
        var suitCount = hand.Cards.Select(card => card.Suit).Distinct().Count();
        var valueGroups = hand.Cards.Select(card => card.Value).GroupBy(v => v).ToList();
        
        if(IsStraightRank(sortedValues) && suitCount == 1)
            return (HandRank.StraightFlush, sortedValues);
        
        if (GetSameValuesCount(valueGroups) == 4)
            return (HandRank.FourOfAKind, sortedValues);
        
        if(valueGroups.Count == 2 
           && valueGroups.Any(g => g.Count() == 3) 
           && valueGroups.Any(g => g.Count() == 2))
            return (HandRank.FullHouse, sortedValues);
        
        if(suitCount == 1)
            return (HandRank.Flush, sortedValues);
        if(IsStraightRank(sortedValues))
            return (HandRank.Straight, sortedValues);
        
        return (HandRank.HighCard, sortedValues);
    }

    private static bool IsStraightRank(List<CardValue> sortedValues)
    {
        if(sortedValues.Count != 5)
            return false;
        
        // A-2-3-4-5 special case
        if(sortedValues.SequenceEqual([CardValue.A, CardValue.Five, CardValue.Four, CardValue.Three, CardValue.Two]))
            return true;
        for (var i = 0; i < sortedValues.Count - 1; i++)
        {
            if (sortedValues[i] - sortedValues[i + 1] != 1)
                return false;
        }
        return true;
    }
    private static int GetSameValuesCount(IEnumerable<IGrouping<CardValue, CardValue>> valueGroups) => valueGroups.Max(g => g.Count());
}