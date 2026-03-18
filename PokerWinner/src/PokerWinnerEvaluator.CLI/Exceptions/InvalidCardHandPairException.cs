namespace PokerWinnerEvaluator.CLI.Exceptions;

public class InvalidCardHandPairException: Exception
{
    public InvalidCardHandPairException()
        : base("Both CardHands are invalid because at least one card appears more than once.")
    {
    }

    public InvalidCardHandPairException(string message)
        : base(message)
    {
    }
}