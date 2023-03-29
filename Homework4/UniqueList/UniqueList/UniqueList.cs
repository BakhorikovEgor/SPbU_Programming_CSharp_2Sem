namespace Lists;

/// <summary>
/// Data structure based on a list with no duplicate elements.
/// </summary>
public class UniqueList : StandardList
{
    private int Contains(int value)
    {
        var position = 0;
        var currentElement = head;
        while (currentElement != null)
        {
            if (currentElement.Value == value)
            {
                return position;
            }
            currentElement = currentElement.Next;
            position++;
        }

        return -1;
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"> This collection doesn`t support repeat values. </exception>
    public override void Add(int value)
    {
        if (Contains(value) == -1)
        {
            base.Add(value);
        }
        else
        {
            throw new ElementAlreadyExistException("Element with the same value already in collection.");
        }
    }


    ///<inheritdoc/>
    /// <exception cref="MissingElementException"> Collection doesn`t contains element with this value. </exception>
    public override bool Remove(int value) => base.Remove(value) 
                                            ? true 
                                            : throw new MissingElementException("No element with this value in collection.");

    /// <inheritdoc/>
    public override bool Replace(int value, int position)
    {
        var positionOfValue = Contains(value);
        if (positionOfValue == -1)
        { 
            return base.Replace(value, position);
        }

        return positionOfValue == position;
    }
}
