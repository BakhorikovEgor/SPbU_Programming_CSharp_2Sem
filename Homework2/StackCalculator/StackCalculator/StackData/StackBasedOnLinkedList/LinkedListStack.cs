namespace StackData;

/// <summary>
/// Stack realization by using LinkedList structure.
/// </summary>
public class LinkedListStack : IStack
{
    private class Node
    {
        public double Value { get; }
        public Node? Next { get; }

        public Node(double value)
        {
            Value = value;
            Next = this;
        }

        public Node(double value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? head;

    /// <inheritdoc/>
    public void Push(double value)
        => head = head == null
                ? new Node(value)
                : new Node(value, head);

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can`t pop from empty stack");
        }

        double returnValue = head.Value;
        head = head.Next == head ? null : head.Next;

        return returnValue;
    }

    /// <inheritdoc/>
    public bool IsEmpty()
        => head == null;
}