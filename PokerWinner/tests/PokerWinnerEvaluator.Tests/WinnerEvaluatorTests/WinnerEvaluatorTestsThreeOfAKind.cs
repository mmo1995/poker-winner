using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests.WinnerEvaluatorTests;

public class WinnerEvaluatorTestsThreeOfAKind
{
    private WinnerEvaluator? _winnerEvaluator;
    
    [Test]
    public void Test_GetWinner_ThreeOfAKind_vs_ThreeOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandThreeOfAKindHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.A),
            new Card(CardSuit.S, CardValue.Four)
        ]);
        
        var cardHandThreeOfAKindLow = new CardHand([
            new Card(CardSuit.C, CardValue.Two),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.S, CardValue.Three),
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.S, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandThreeOfAKindHigh, cardHandThreeOfAKindLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandThreeOfAKindHigh));
    }

    [Test]
    public void Test_GetWinner_ThreeOfAKind_vs_TwoPairs()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.S, CardValue.Four)
        ]);
        
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandThreeOfAKind, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandThreeOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_ThreeOfAKind_vs_Pair()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.S, CardValue.Four)
        ]);
        
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Six),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.H, CardValue.Six),
            new Card(CardSuit.C, CardValue.A)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandThreeOfAKind, cardHandPair);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandThreeOfAKind));
    }
    
    [Test]
    public void Test_GetWinner_ThreeOfAKind_vs_HighCard()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator(), new CardHandPairValidator());
        
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Four),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.H, CardValue.Two),
            new Card(CardSuit.S, CardValue.Four)
        ]);
        
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.S, CardValue.Three),
            new Card(CardSuit.H, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandThreeOfAKind, cardHandHighCard);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandThreeOfAKind));
    }
}