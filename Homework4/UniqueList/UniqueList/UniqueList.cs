namespace List;

/// <summary>
/// Data structure based on a list with no duplicate elements.
/// </summary>
public class UniqueList : List
{
    private int Contains(int value)
    {
        int position = -1;
        ListElement? currentElement = head;
        while (currentElement != null)
        {
            position++;
            if (currentElement.Value == value)
            {
                return position;
            }
            currentElement = currentElement.Next;
        }

        return position;
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"> This list doesn`t support repeat values. </exception>
    public override void Add(int value)
    {
        if (Contains(value) != -1)
        {
            base.Add(value);
        }
        throw new ElementAlreadyExistException("Can`t add repeat element in UniqueList");
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"> 
    /// Value we want to add is already in UniqueList. 
    /// And its position is not equal to replace position.
    /// </exception>
    public override bool Replace(int value, int position)
    {
        int positionOfValue = Contains(value);
        if (positionOfValue == -1)
        { 
            return base.Replace(value, position);
        }
        
        if (positionOfValue == position) 
        {
            return true;
        }

        throw new ElementAlreadyExistException("This element is already in UniqueList");
    }
}
