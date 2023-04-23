namespace SkipList;

internal class WrongSkipListElementException: Exception
{
    public WrongSkipListElementException() : base() { }
    public WrongSkipListElementException(string message) : base(message) { }
}
