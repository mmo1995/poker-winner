using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Application;

public class WinnerEvaluator(IRankCalculator rankCalculator, ICardHandPairValidator cardHandPairValidator): IWinnerEvaluator
{
    public CardHand? GetWinner(CardHand hand1, CardHand hand2)
    {
        cardHandPairValidator.Validate(hand1, hand2);
        
        var (hand1Rank, hand1Values) = rankCalculator.CalculateRank(hand1);
        var (hand2Rank, hand2Values) = rankCalculator.CalculateRank(hand2);

        if (hand1Rank != hand2Rank)
            return hand1Rank > hand2Rank ? hand1 : hand2;

        var hand1SortedValues = hand1Values.OrderByDescending(v => v).ToList();
        var hand2SortedValues = hand2Values.OrderByDescending(v => v).ToList();
        
        switch (hand1Rank)
        {
            case HandRank.StraightFlush:
                return hand1SortedValues[0] > hand2SortedValues[0] ? hand1 : hand2;
            case HandRank.FourOfAKind:
            {
                var fourOfAKindHand1 = hand1SortedValues.GroupBy(v => v).First(g => g.Count() == 4).Key;
                var fourOfAKindHand2 = hand2SortedValues.GroupBy(v => v).First(g => g.Count() == 4).Key;

                return fourOfAKindHand1 > fourOfAKindHand2 ? hand1 : hand2;
            }
            case HandRank.FullHouse:
            {
                var fullHouseTripletHand1 = hand1SortedValues.GroupBy(v => v).First(g => g.Count() == 3).Key;
                var fullHouseTripletHand2 = hand2SortedValues.GroupBy(v => v).First(g => g.Count() == 3).Key;

                return fullHouseTripletHand1 > fullHouseTripletHand2 ? hand1 : hand2;
            }
            case HandRank.Flush:
            {
                for (var i = 0; i < hand1SortedValues.Count; i++)
                {
                    if (hand1SortedValues[i] == hand2SortedValues[i])
                        continue;

                    return hand1SortedValues[i] > hand2SortedValues[i] ? hand1 : hand2;
                }
                return null;
            }
            case HandRank.Straight:
                if(hand1SortedValues[0] == hand2SortedValues[0])
                    return null;
                return hand1SortedValues[0] > hand2SortedValues[0] ? hand1 : hand2;
            case HandRank.ThreeOfAKind:
                return hand1SortedValues[0] > hand2SortedValues[0] ? hand1 : hand2;
            case HandRank.TwoPairs:
            {
                var hand1Pairs = hand1SortedValues.GroupBy(v => v)
                    .Where(g => g.Count() == 2)
                    .Select(g => g.Key)
                    .OrderByDescending(v => v)
                    .ToList();

                var hand2Pairs = hand2SortedValues.GroupBy(v => v)
                    .Where(g => g.Count() == 2)
                    .Select(g => g.Key)
                    .OrderByDescending(v => v)
                    .ToList();

                if (hand1Pairs[0] != hand2Pairs[0])
                    return hand1Pairs[0] > hand2Pairs[0] ? hand1 : hand2;

                if (hand1Pairs[1] != hand2Pairs[1])
                    return hand1Pairs[1] > hand2Pairs[1] ? hand1 : hand2;

                var hand1Kicker = hand1SortedValues.First(v => !hand1Pairs.Contains(v));
                var hand2Kicker = hand2SortedValues.First(v => !hand2Pairs.Contains(v));

                if (hand1Kicker == hand2Kicker)
                    return null;

                return hand1Kicker > hand2Kicker ? hand1 : hand2;
            }
            case HandRank.Pair:
            {
                var hand1Pair = hand1SortedValues.GroupBy(v => v)
                    .First(g => g.Count() == 2).Key;

                var hand2Pair = hand2SortedValues.GroupBy(v => v)
                    .First(g => g.Count() == 2).Key;

                if (hand1Pair != hand2Pair)
                    return hand1Pair > hand2Pair ? hand1 : hand2;

                var hand1Kickers = hand1SortedValues.Where(v => v != hand1Pair).OrderByDescending(v => v).ToList();
                var hand2Kickers = hand2SortedValues.Where(v => v != hand2Pair).OrderByDescending(v => v).ToList();

                for (var i = 0; i < hand1Kickers.Count; i++)
                {
                    if (hand1Kickers[i] == hand2Kickers[i])
                        continue;

                    return hand1Kickers[i] > hand2Kickers[i] ? hand1 : hand2;
                }

                return null;
            }
            case HandRank.HighCard:
            {
                for (var i = 0; i < hand1SortedValues.Count; i++)
                {
                    if (hand1SortedValues[i] == hand2SortedValues[i])
                        continue;

                    return hand1SortedValues[i] > hand2SortedValues[i] ? hand1 : hand2;
                }

                return null;
            }
                
            default:
                return null;
        }
    }
}