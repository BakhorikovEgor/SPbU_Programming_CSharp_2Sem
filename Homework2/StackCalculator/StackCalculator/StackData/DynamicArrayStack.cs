
namespace Calculator.StackData
{
    internal class DynamicArrayStack : IStack
    {
        private List<double> array;

        public int Count { get; private set; } = 0;

        public DynamicArrayStack()
        {
            array = new List<double>(90);
        }

        public void Push(double value)
        {
            array.Insert(Count,value);
            Count++;
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty !");
            }

            return array.ElementAt(--Count);
        }


        public bool IsEmpty() => Count == 0;
    }
}
