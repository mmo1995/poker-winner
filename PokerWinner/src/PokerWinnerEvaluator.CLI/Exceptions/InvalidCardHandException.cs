namespace PokerWinnerEvaluator.CLI.Exceptions;

public class InvalidCardHandException: Exception
{
    public InvalidCardHandException()
        : base("Invalid Card Hand.")
    {
    }

    public InvalidCardHandException(string message)
        : base(message)
    {
    }
}