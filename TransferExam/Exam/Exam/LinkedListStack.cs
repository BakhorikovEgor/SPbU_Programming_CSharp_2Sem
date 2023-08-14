namespace Exam;

/// <summary>
/// Stack realization by using LinkedList structure.
/// </summary>
public class LinkedListStack 
{
    private class Node
    {
        public char Value { get; }
        public Node? Next { get; }

        public Node(char value)
        {
            Value = value;
            Next = this;
        }

        public Node(char value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? head;

    /// <summary>
    /// Add element to the top of stack.
    /// </summary>
    /// <param name="value"></param>
    public void Push(char value)
        => head = head == null
                ? new Node(value)
                : new Node(value, head);

    /// <summary>
    /// Delete element from the top of stack and return it.
    /// </summary>
    /// <returns> Element on the top. </returns>
    /// <exception cref="InvalidOperationException"> Stack is empty. </exception>
    public char Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can`t pop from empty stack");
        }

        char returnValue = head.Value;
        head = head.Next == head 
            ? null 
            : head.Next;

        return returnValue;
    }

    /// <summary>
    /// Check if stack has elements.
    /// </summary>
    public bool IsEmpty()
        => head == null;
}