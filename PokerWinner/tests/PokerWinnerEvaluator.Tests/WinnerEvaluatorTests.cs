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
}