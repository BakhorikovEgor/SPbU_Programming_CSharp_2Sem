namespace StackData.LinkedList
{
    /// <summary>
    /// Stack realization by using LinkedList structure.
    /// </summary>
    internal class LinkedListStack : IStack
    {
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
}