
namespace Calculator.StackData {
    internal class LinkedListStack : IStack
    {
        private Node? head;
        private Node? tail;
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
                throw new InvalidOperationException("Stack is empty");
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

        public bool IsEmpty() => Count == 0;
    }
}