namespace Calculator.StackData
{
    /// <summary>
    /// Stack realization by using dynamic array.
    /// </summary>
    internal class DynamicArrayStack : IStack
    {
        private List<double> array;

        /// <summary>
        /// number of filled cells in array.
        /// </summary>
        public int Count { get; private set; } = 0;

        public DynamicArrayStack()
        {
            array = new List<double>(90);
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can`t pop from empty stack");
            }

            return array.ElementAt(--Count);
        }

        public void Push(double value) => array.Insert(Count++, value);

        private bool IsEmpty() => Count == 0;
    }
}
