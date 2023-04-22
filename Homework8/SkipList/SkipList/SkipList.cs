using System.Collections;

namespace SkipListRealization;

internal class SkipList<T> where T : IComparable<T>
{ 
    class SkipListNode
    {
        public SkipListNode[] Next { get; set; }

        Random _rand = new Random();
        public T Key { get; }

        public SkipListNode(T key, int level)
        {
            Key = key;     
            Next = new SkipListNode[level];
        }

        public int CompareTo(SkipListNode? other)
        {
            if (other == null)
            {
                throw new ArgumentException();
            }
            return Key.CompareTo(other.Key);
        }
    }

}

