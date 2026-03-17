using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests;

public class WinnerEvaluatorTests
{
    private WinnerEvaluator? _winnerEvaluator;
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_HighCard()
    {
     //Arrange
     _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
     var cardHandStraightFlush = new CardHand([
             new Card(CardSuit.C, CardValue.Five),
             new Card(CardSuit.C, CardValue.Six),
             new Card(CardSuit.C, CardValue.Seven),
             new Card(CardSuit.C, CardValue.Eight),
             new Card(CardSuit.C, CardValue.Nine)
         ]
     );
     var cardHandHighCard = new CardHand([
         new Card(CardSuit.C, CardValue.Five),
         new Card(CardSuit.D, CardValue.Q),
         new Card(CardSuit.H, CardValue.Three),
         new Card(CardSuit.S, CardValue.Seven),
         new Card(CardSuit.C, CardValue.Two)
     ]);
     
     //Act
     var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandHighCard);

     //Assert
     Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_FourOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandFourOfAKind);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_FullHouse()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandFullHouse);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_Flush()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandFlush);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_Straight()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandStraight);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_ThreeOfAKind()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlush = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.C, CardValue.Five)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandThreeOfAKind);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
}