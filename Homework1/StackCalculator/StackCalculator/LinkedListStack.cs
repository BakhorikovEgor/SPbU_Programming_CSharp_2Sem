using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    internal class LinkedListStack : IStack
    {
        private LinkedList<int> list;

        public int Count { get; private set; } = 0;

        public LinkedListStack()
        {
            list = new LinkedList<int>();
        }

        public void Push(int value)
        {
            list.Append(value);
            Count++;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return list.ElementAt(--Count);
        }

        public bool IsEmpty() => Count == 0;
    }
}
