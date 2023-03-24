namespace List;

/// <summary>
/// Exception for collections with unique elements.
/// </summary>
public class ElementAlreadyExistException: Exception
{
    public ElementAlreadyExistException() { }

    public ElementAlreadyExistException(string message) : base(message) { }

    public ElementAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }

}
