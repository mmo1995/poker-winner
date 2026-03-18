using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsPair
{
    private WinnerEvaluator? _winnerEvaluator;

    [Test]
    public void Test_GetWinner_Pair_vs_Pair_different_pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandPairHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Ten),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.C, CardValue.A)
        ]);
        
        var cardHandPairLow = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Three),
            new Card(CardSuit.H, CardValue.J),
            new Card(CardSuit.H, CardValue.Four),
            new Card(CardSuit.C, CardValue.Seven)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandPairHigh, cardHandPairLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandPairHigh));
    }
    
    [Test]
    public void Test_GetWinner_Pair_vs_Pair_same_pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandPairHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Ten),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.C, CardValue.A)
        ]);
        
        var cardHandPairLow = new CardHand([
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.D, CardValue.Three),
            new Card(CardSuit.H, CardValue.J),
            new Card(CardSuit.S, CardValue.Six),
            new Card(CardSuit.C, CardValue.Seven)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandPairHigh, cardHandPairLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandPairHigh));
    }
    
    [Test]
    public void Test_GetWinner_Pair_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Ten),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.C, CardValue.A)
        ]);
        
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.D, CardValue.A),
            new Card(CardSuit.S, CardValue.Three),
            new Card(CardSuit.H, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandPair, cardHandHighCard);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandPair));
    }
}