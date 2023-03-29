namespace Lists;

/// <summary>
/// Collection of elements.
/// </summary>
public class StandardList
{
    /// <summary>
    /// A part of list.
    /// </summary>
    protected class ListElement
    {
        /// <summary>
        /// Link to the next element.
        /// </summary>
        public ListElement? Next { get; set; }

        public int Value { get; set; }

        public ListElement (int value, ListElement? next)
        {
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// Recently added item.
    /// </summary>
    protected ListElement? head = null;

    /// <summary>
    /// Add new element in list.
    /// </summary>
    public virtual void Add(int value) => head = new ListElement(value, head);

    /// <summary>
    /// Remove element from list by value (first found element).
    /// </summary>
    /// <returns> True if the element was removed. Else false. </returns>
    public virtual bool Remove(int value)
    {
        if (head == null)
        {
            return false;
        }

        if (head.Value == value)
        {
            head = head.Next;
            return true;
        }

        var previousElement = head;
        ListElement? currentElement = head.Next;
        while (currentElement != null)
        {
            if (currentElement.Value.Equals(value))
            {
                previousElement.Next = currentElement.Next;
                return true;
            }
            previousElement = currentElement;
            currentElement = currentElement.Next;
        }

        return false;
    }
    
    /// <summary>
    /// Replace element in list by position to another value (first found element).
    /// </summary>
    /// <returns> True if element was replaced. Else false. </returns>
    public virtual bool Replace(int value, int position)
    {
        ListElement? currentElement = head;
        for (var i = 0; i <= position; ++i)
        {
            if (currentElement == null)
            {
                return false;
            }

            if (i == position) 
            {
                currentElement.Value = value;
                return true;
            }
            currentElement = currentElement.Next;
        }
        return false;
    }
}