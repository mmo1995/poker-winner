using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsFullHouse
{
    private WinnerEvaluator? _winnerEvaluator;
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_FullHouse()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouseHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFullHouseLow = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.A),
            new Card(CardSuit.H, CardValue.A),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.H, CardValue.Four)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouseHigh, cardHandFullHouseLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouseHigh));
    }

    [Test]
    public void Test_GetWinner_FullHouse_vs_Flush()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Seven)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandFlush);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_Straight()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.H, CardValue.Nine)
        ]);
        var cardHandStraight = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandStraight);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_ThreeOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
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
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandThreeOfAKind);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_TwoPairs()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Four),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_Pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Six),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandPair);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
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
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouse, cardHandHighCard);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouse));
    }
}