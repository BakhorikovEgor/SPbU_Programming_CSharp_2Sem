namespace StackData;

/// <summary>
/// Class for realization LinkedList structure.
/// Node is a one part of linked list.
/// </summary>
internal class Node
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
