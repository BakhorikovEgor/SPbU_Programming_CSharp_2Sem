namespace ParsingTree;

public class WrongExpressionException: Exception
{
    public WrongExpressionException() : base() { }
    public WrongExpressionException(string message) : base(message) { }

}
