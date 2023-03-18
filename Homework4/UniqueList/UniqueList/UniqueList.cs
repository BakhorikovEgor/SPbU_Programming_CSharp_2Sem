namespace List;

/// <summary>
/// Data structure based on a singly linked list with no duplicate elements.
/// </summary>
/// <typeparam name="T"> Type of element value. </typeparam>
public class UniqueList<T> : LinkedList<T> where T : IEquatable<T>
{
    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"> </exception>
    public override void Add(T value)
    {
        if (!Contains(value))
        {
            base.Add(value);
        }
        throw new ElementAlreadyExistException("Can`t add repeat element in UniqueList");
    }

    /// <summary>
    /// Replace element by position.
    /// </summary>
    /// <returns> False if element with this value already exist</returns>
    public override bool Replace(T value, int position)
    {
        if (!Contains(value))
        { 
            return base.Replace(value, position);
        }

        if ()
        return false;
    }
}
