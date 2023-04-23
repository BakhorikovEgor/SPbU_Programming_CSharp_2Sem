namespace SkipListRealization;

/// <summary>
/// Thrown when there is an invalid element in the missing list.
/// </summary>
internal class WrongSkipListElementException: Exception
{
    public WrongSkipListElementException() : base() { }
    public WrongSkipListElementException(string message) : base(message) { }
}
