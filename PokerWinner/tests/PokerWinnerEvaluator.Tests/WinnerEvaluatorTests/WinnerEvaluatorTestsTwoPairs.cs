using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsTwoPairs
{
    private WinnerEvaluator? _winnerEvaluator;

    [Test]
    public void Test_GetWinner_TwoPairs_vs_TwoPairs_different_high_pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandTwoPairsHigh = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        var cardHandTwoPairsLow = new CardHand([
            new Card(CardSuit.H, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.H, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Three)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandTwoPairsHigh, cardHandTwoPairsLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandTwoPairsHigh));
    }
    
    [Test]
    public void Test_GetWinner_TwoPairs_vs_TwoPairs_same_high_pair_different_low_pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandTwoPairsHigh = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        var cardHandTwoPairsLow = new CardHand([
            new Card(CardSuit.H, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.D, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Three)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandTwoPairsHigh, cardHandTwoPairsLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandTwoPairsHigh));
    }
    
    [Test]
    public void Test_GetWinner_TwoPairs_vs_TwoPairs_same_high_pair_same_low_pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandTwoPairsHigh = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.A)
        ]);
        
        var cardHandTwoPairsLow = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Three)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandTwoPairsHigh, cardHandTwoPairsLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandTwoPairsHigh));
    }
    
    [Test]
    public void Test_GetWinner_TwoPairs_vs_Pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Ten),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.C, CardValue.A)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandPair, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandTwoPairs));
    }
    
    [Test]
    public void Test_GetWinner_TwoPairs_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.S, CardValue.Three),
            new Card(CardSuit.H, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandHighCard, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandTwoPairs));
    }
}