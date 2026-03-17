using PokerWinnerEvaluator.CLI.Contracts;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.CLI.Application;

public class WinnerEvaluator(IRankCalculator rankCalculator): IWinnerEvaluator
{
    public CardHand GetWinner(CardHand hand1, CardHand hand2)
    {
        var (hand1Rank, hand1Values) = rankCalculator.CalculateRank(hand1);
        var (hand2Rank, hand2Values) = rankCalculator.CalculateRank(hand2);

        if (hand1Rank != hand2Rank)
            return hand1Rank > hand2Rank ? hand1 : hand2;
        return null;
    }
}