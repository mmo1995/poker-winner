using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsFlush
{
    private WinnerEvaluator? _winnerEvaluator;
    
    [Test]
    public void Test_GetWinner_Flush_vs_Flush()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlushHigh = new CardHand([
            new Card(CardSuit.S, CardValue.A),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandFlushLow = new CardHand([
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.H, CardValue.Four),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.H, CardValue.Seven)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlushLow, cardHandFlushHigh);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlushHigh));
    }

    [Test]
    public void Test_GetWinner_Flush_vs_Straight()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlush, cardHandStraight);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlush));
    }
    
    [Test]
    public void Test_GetWinner_Flush_vs_ThreeOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Six),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlush, cardHandThreeOfAKind);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlush));
    }
    
    [Test]
    public void Test_GetWinner_Flush_vs_TwoPair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlush, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlush));
    }
    
    [Test]
    public void Test_GetWinner_Flush_vs_Pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlush, cardHandPair);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlush));
    }
    
    [Test]
    public void Test_GetWinner_Flush_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFlush, cardHandHighCard);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFlush));
    }
}