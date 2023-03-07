

namespace Calculator.StackData
{
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
