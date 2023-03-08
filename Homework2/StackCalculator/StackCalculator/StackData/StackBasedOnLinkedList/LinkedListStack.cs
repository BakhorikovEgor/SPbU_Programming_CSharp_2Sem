namespace Calculator.StackData
{
    /// <summary>
    /// Stack realization by using linked list structure.
    /// </summary>
    internal class LinkedListStack : IStack
    {
        private Node? head;
        private Node? tail;

        /// <summary>
        /// number of existing nodes.
        /// </summary>
        public int Count { get; private set; } = 0;

        public void Push(double value)
        {
            Node newNode = new Node(value);
            if (Count == 0)
            {
                head = newNode;
            }
            else if (Count == 1)
            {
                head.Next = newNode;
                tail = head.Next;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can`t pop from empty stack");
            }

            if (Count == 1)
            {
                Count--;
                return head.Value;
            }

            Node tempNode = head;
            while (tempNode.Next != tail)
            {
                tempNode = tempNode.Next;
            }

            double returnValue = tempNode.Next.Value;

            tempNode.Next = null;
            tail = tempNode;
            Count--;

            return returnValue;
        }

        private bool IsEmpty() => Count == 0;
    }
}