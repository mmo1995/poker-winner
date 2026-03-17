using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests;

public class RankCalculatorTests
{   
    private RankCalculator? _rankCalculator;

    [Test]
    public void Test_Calculates_StraightFlush()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandStraightFlush);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.StraightFlush));
    }
    
    [Test]
    public void Test_Calculates_FourOfAKind()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandFourOfAKind);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.FourOfAKind));
    }
}