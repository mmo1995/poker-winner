using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsHighCard
{
    private WinnerEvaluator? _winnerEvaluator;

    [Test]
    public void Test_GetWinner_HighCard_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandHighCardHigh = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.D, CardValue.A),
            new Card(CardSuit.S, CardValue.Three),
            new Card(CardSuit.H, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Two)
        ]);
        
        var cardHandHighCardLow = new CardHand([
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.D, CardValue.J),
            new Card(CardSuit.S, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.H, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandHighCardHigh, cardHandHighCardLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandHighCardHigh));
    }
}