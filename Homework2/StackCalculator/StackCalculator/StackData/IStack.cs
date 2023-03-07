namespace Calculator.StackData
{
    /// <summary>
    /// Stack implementation for stack calculator realization.
    /// </summary>
    public interface IStack
    {
        public int Count { get; }
        public void Push(double value);

        public double Pop();

        public bool IsEmpty();
    }
}
