namespace StackData.DynamicArray
{
    /// <summary>
    /// Stack realization by using dynamic array.
    /// </summary>
    public class DynamicArrayStack : IStack
    {
        private List<double> array;
        private int count;

        public DynamicArrayStack()
        {
            array = new List<double>();
        }

        /// <inheritdoc/>
        public void Push(double value) 
            => array.Insert(count++, value);

        /// <inheritdoc/>
        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can`t pop from empty stack");
            }

            return array.ElementAt(--count);
        }

        /// <inheritdoc/>
        public bool IsEmpty() 
            => count == 0;
    }
}
