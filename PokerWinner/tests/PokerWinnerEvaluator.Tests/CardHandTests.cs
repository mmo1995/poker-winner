using PokerWinnerEvaluator.CLI.Domain;
using PokerWinnerEvaluator.CLI.Exceptions;

namespace PokerWinnerEvaluator.Tests;

public class CardHandTests
{
    private CardHand? _cardHand;
    [Test]
    public void Test_CardHand_Throws_Exception_When_Cards_Are_Not_Unique()
    {
        //Arrange & Act & Assert
        Assert.Throws<InvalidCardHandException>(() => _cardHand = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.C, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]));
    }
}