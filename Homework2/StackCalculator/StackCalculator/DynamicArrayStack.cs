
namespace StackCalculator
{
    internal class DynamicArrayStack : IStack
    {
        private List<int> array;

        public int Count { get; private set; } = 0;

        public DynamicArrayStack()
        {
            array = new List<int>();
        }

        public void Push(int value)
        {
            array.Add(value);
            Count++;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty !");
            }

            return array[--Count];
        }


        public bool IsEmpty() => Count == 0;
    }
}
