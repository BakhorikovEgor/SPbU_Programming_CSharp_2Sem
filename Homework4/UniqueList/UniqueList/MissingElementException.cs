namespace List;

/// <summary>
/// Indicates the absence of an element in the collection.
/// </summary>
internal class MissingElementException: Exception
{
    public MissingElementException() { }

    public MissingElementException(string message) : base(message) { }

    public MissingElementException(string message, Exception innerException) : base(message, innerException) { }
}
