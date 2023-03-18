namespace List;

/// <summary>
/// A class that is a singly linked list.
/// </summary>
/// <typeparam name="T"> Value of list elements. </typeparam>
public class LinkedList<T> where T : IEquatable<T>
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

        public T Value { get; set; }

        /// <summary> 
        /// Constructor. 
        /// </summary>
        /// <exception cref="ArgumentNullException">Can`t create element with null value.</exception>
        public ListElement (T value, ListElement? next)
        {
            if (value == null)
            {
                throw new ArgumentNullException ("Value can`t be null.");
            }
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// Recently added item.
    /// </summary>
    protected ListElement? head;

    /// <summary>
    /// Check if element is in list.
    /// </summary>
    /// <param name="value"> Element value. </param>
    /// <returns> Position is contains else -1</returns>
    protected int Contains(T value)
    {
        var currentElement = head;
        var position = 0;
        while (currentElement != null)
        {
            if (currentElement.Value.Equals(value))
            {
                return position;
            }
            currentElement = currentElement.Next;
            position++;
        }

        return -1;
    }

    /// <summary>
    /// Add new element in list.
    /// </summary>
    public virtual void Add(T value) => head = new ListElement(value, head);

    /// <summary>
    /// Remove element from list by value (first found element).
    /// </summary>
    /// <returns> True if the element was deleted. </returns>
    /// <exception cref="MissingElementException"> Can`t find element. </exception>
    public virtual void Remove(T value)
    {
        if (head == null)
        {
            throw new MissingElementException("LinkedList is empty.");
        }

        if (Contains(value) != -1)
        {
            throw new MissingElementException($"LinkedList does`nt contains element with value {value}.");
        }

        if (head.Value.Equals(value))
        {
            head = head.Next;
            return;
        }

        ListElement previousElement = head;
        ListElement? currentElement = head.Next;
        while (currentElement != null)
        {
            if (currentElement.Value.Equals(value))
            {
                previousElement.Next = currentElement.Next;
                return;
            }
            previousElement = currentElement;
            currentElement = currentElement.Next;
        }
    }
    
    /// <summary>
    /// Replace element in list by position to another value (first found element).
    /// </summary>
    /// <returns> True if element was replaced. </returns>
    public virtual bool Replace(T value, int position)
    {
        if (head == null)
        {
            if (position == 0)
            {
                head = new ListElement(value, null);
                return true;
            }
            return false;
        }

        ListElement? currentElement = head.Next;
        for (int i = 1; i < position; ++i)
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
