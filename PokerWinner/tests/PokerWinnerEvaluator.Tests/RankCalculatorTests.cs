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
    public void Test_Calculates_StraightFlush_Special_Ass_AsOne()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.A),
                new Card(CardSuit.C, CardValue.Two),
                new Card(CardSuit.C, CardValue.Three),
                new Card(CardSuit.C, CardValue.Four),
                new Card(CardSuit.C, CardValue.Five)
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
    
    [Test]
    public void Test_Calculates_FullHouse()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandFullHouse);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.FullHouse));
    }
    [Test]
    public void Test_Calculates_Flush()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandFlush);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.Flush));
    }
    
    [Test]
    public void Test_Calculates_Straight()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandStraight);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.Straight));
    }
    [Test]
    public void Test_Calculates_Straight_Special_Ass_AsOne()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.A),
            new Card(CardSuit.D, CardValue.Two),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Five)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandStraight);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.Straight));
    }
    
    [Test]
    public void Test_Calculates_ThreeOfAKind()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandThreeOfAKind);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.ThreeOfAKind));
    }
    
    [Test]
    public void Test_Calculates_TwoPairs()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandTwoPairs);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.TwoPairs));
    }
    
    [Test]
    public void Test_Calculates_Pair()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandPair);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.Pair));
    }
    
    [Test]
    public void Test_Calculates_HighCard()
    {
        //Arrange
        _rankCalculator = new RankCalculator();
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Two)
        ]);
        
        //Act
        var (rank, _) = _rankCalculator.CalculateRank(cardHandHighCard);
        //Assert
        Assert.That(rank, Is.EqualTo(HandRank.HighCard));
    }
}