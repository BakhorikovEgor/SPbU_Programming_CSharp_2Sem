namespace Calculator.StackData
{
    /// <summary>
    /// Stack implementation for stack calculator realization.
    /// </summary>
    public interface IStack
    {
        //number of existing elements in stack
        public int Count { get; }

        //add element in stack
        public void Push(double value);

        //delete element from stack (LIFO rule) if stack isn`t empty.
        public double Pop();
    }
}
