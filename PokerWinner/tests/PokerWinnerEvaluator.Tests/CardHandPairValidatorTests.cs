using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;
using PokerWinnerEvaluator.CLI.Exceptions;

namespace PokerWinnerEvaluator.Tests;

public class CardHandPairValidatorTests
{
    private CardHandPairValidator? _cardHandPairValidator;
    [Test]
    public void Test_Throws_Exception_When_Cards_Are_Not_Unique_In_Pair()
    {
        //Arrange
        _cardHandPairValidator = new CardHandPairValidator();
        var cardHand1 = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.C, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);

        var cardHand2 = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Nine)
        ]);

        //Act & Assert
        Assert.Throws<InvalidCardHandPairException>(() => _cardHandPairValidator.Validate(cardHand1, cardHand2));
    }
    
    [Test]
    public void Test_Does_Not_Throw_Exception_When_Cards_Are_Unique_In_Pair()
    {
        //Arrange
        _cardHandPairValidator = new CardHandPairValidator();
        var cardHand1 = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.C, CardValue.Seven),
            new Card(CardSuit.C, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
        ]);

        var cardHand2 = new CardHand([
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.S, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.S, CardValue.Nine)
        ]);

        //Act & Assert
        Assert.DoesNotThrow(() => _cardHandPairValidator.Validate(cardHand1, cardHand2));
    }
}