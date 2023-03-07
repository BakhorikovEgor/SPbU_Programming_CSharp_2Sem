namespace Calculator.StackData
{
    public interface IStack
    {
        public int Count { get;}
        public void Push(double value);

        public double Pop();

        public bool IsEmpty();
    }
}
