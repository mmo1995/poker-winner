using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsFourOfAKind
{
    private WinnerEvaluator? _winnerEvaluator;
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_FourOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKindLow = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.A)
        ]);
        var cardHandFourOfAKindHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Seven),
            new Card(CardSuit.D, CardValue.Seven),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKindLow, cardHandFourOfAKindHigh);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKindHigh));
    }

    [Test]
    public void Test_GetWinner_FourOfAKind_vs_FullHouse()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.H, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandFullHouse);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_Flush()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Six),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandFlush);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_Straight()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandStraight = new CardHand([
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Ten)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandStraight);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_ThreeOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Six)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandThreeOfAKind);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_TwoPairs()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_Pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandPair);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.C, CardValue.A),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKind, cardHandHighCard);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKind));
    }
}