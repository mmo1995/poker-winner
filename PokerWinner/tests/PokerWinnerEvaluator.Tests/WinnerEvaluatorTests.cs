using PokerWinnerEvaluator.CLI.Application;
using PokerWinnerEvaluator.CLI.Domain;

namespace PokerWinnerEvaluator.Tests;

public class WinnerEvaluatorTests
{
    private WinnerEvaluator? _winnerEvaluator;

    #region StraightFlush
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_StraightFlush()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandStraightFlushLowValue = new CardHand([
                new Card(CardSuit.C, CardValue.Five),
                new Card(CardSuit.C, CardValue.Six),
                new Card(CardSuit.C, CardValue.Seven),
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine)
            ]
        );
        var cardHandStraightFlushHighValue = new CardHand([
                new Card(CardSuit.C, CardValue.Eight),
                new Card(CardSuit.C, CardValue.Nine),
                new Card(CardSuit.C, CardValue.Ten),
                new Card(CardSuit.C, CardValue.J),
                new Card(CardSuit.C, CardValue.Q)
            ]
        );
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlushLowValue, cardHandStraightFlushHighValue);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlushHighValue));
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
    
    [Test]
    public void Test_GetWinner_StraightFlush_vs_TwoPairs()
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
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandTwoPairs);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    [Test]
    public void Test_GetWinner_StraightFlush_vs_Pair()
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
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Two)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandStraightFlush, cardHandPair);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandStraightFlush));
    }
    
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
    
    #endregion StraightFlush

    #region FourOfAKind
    
    [Test]
    public void Test_GetWinner_FourOfAKind_vs_FourOfAKind_different_quad()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
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
    public void Test_GetWinner_FourOfAKind_vs_FourOfAKind_same_quad()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKindHighKicker = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.A)
        ]);
        var cardHandFourOfAKindLowKicker = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFourOfAKindHighKicker, cardHandFourOfAKindLowKicker);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFourOfAKindHighKicker));
    }

    [Test]
    public void Test_GetWinner_FourOfAKind_vs_FullHouse()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFlush = new CardHand([
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Six),
            new Card(CardSuit.H, CardValue.Seven),
            new Card(CardSuit.S, CardValue.Eight),
            new Card(CardSuit.C, CardValue.Nine)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.C, CardValue.Five)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Five),
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFourOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
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

    #endregion FourOfAKind

    #region FullHouse
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_FullHouse_different_triplet()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouseHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFullHouseLow = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Four)
        ]);
     
        //Act
        var winningCardHand = _winnerEvaluator.GetWinner(cardHandFullHouseHigh, cardHandFullHouseLow);

        //Assert
        Assert.That(winningCardHand, Is.EqualTo(cardHandFullHouseHigh));
    }
    
    [Test]
    public void Test_GetWinner_FullHouse_vs_FullHouse_same_triplet()
    {
        //Arrange
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouseHigh = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandFullHouseLow = new CardHand([
            new Card(CardSuit.C, CardValue.Four),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Four),
            new Card(CardSuit.C, CardValue.Five)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
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
            new Card(CardSuit.S, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandStraight = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandThreeOfAKind = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Two),
            new Card(CardSuit.C, CardValue.Five)
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandTwoPairs = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Nine),
            new Card(CardSuit.S, CardValue.Nine),
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandPair = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Q),
            new Card(CardSuit.H, CardValue.Three),
            new Card(CardSuit.S, CardValue.Five),
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
        _winnerEvaluator = new WinnerEvaluator(new RankCalculator());
        var cardHandFullHouse = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
            new Card(CardSuit.D, CardValue.Five),
            new Card(CardSuit.H, CardValue.Five),
            new Card(CardSuit.S, CardValue.Nine),
            new Card(CardSuit.C, CardValue.Nine)
        ]);
        var cardHandHighCard = new CardHand([
            new Card(CardSuit.C, CardValue.Five),
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

    #endregion FullHouse
}