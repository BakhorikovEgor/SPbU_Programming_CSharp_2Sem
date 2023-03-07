namespace Calculator.StackData
{
    /// <summary>
    /// Class for realization linked list structure.
    /// Node is a one part of linked list.
    /// </summary>
    internal class Node
    {
        public double Value { get; private set; }
        public Node? Next { get; set; }

        public Node(double value)
        {
            Value = value;
        }

        public void SetValue(double value)
        {
            Value = value;
        }
    }
}
