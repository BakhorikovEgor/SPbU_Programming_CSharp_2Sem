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

    public void Push(char value)
        => head = head == null
                ? new Node(value)
                : new Node(value, head);

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

    public bool IsEmpty()
        => head == null;
}