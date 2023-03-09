namespace Calculator.StackData
{
    /// <summary>
    /// Stack realization by using linked list structure.
    /// </summary>
    internal class LinkedListStack : IStack
    {
        private Node? head;

        public int Count { get; private set; } = 0;

        public void Push(double value)
        {
            Node newNode = new Node(value);
            if (Count == 0)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            Count++;
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can`t pop from empty stack");
            }

            double returnValue = head.Value;
            head = head.Next;
            Count--;
            

            return returnValue;
        }

        private bool IsEmpty() => Count == 0;
    }
}