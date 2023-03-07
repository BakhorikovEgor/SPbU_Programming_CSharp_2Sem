namespace StackCalculator
{
    public interface IStack
    {
        public void Push(int value);

        public int Pop();

        public bool IsEmpty();
    }
}
