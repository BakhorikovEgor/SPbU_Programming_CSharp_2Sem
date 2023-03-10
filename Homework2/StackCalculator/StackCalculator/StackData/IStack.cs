namespace Calculator.StackData
{
    /// <summary>
    /// Stack implementation for stack calculator realization.
    /// </summary>
    public interface IStack
    {
        ///number of existing elements in stack
        public int Count { get; }

        /// <summary>
        /// add element in stack
        /// </summary>
        /// <param name="value"> value to add</param>
        public void Push(double value);

        /// <summary>
        /// delete element from stack (LIFO rule) if stack isn`t empty.
        /// </summary>
        /// <returns> dealeating value </returns>
        public double Pop();
    }
}
