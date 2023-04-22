using System.Collections;

namespace SkipListRealization;

internal class SkipList<T> : IList<T>  where T : IComparable<T>
{ 
    class SkipListNode
    {
        public SkipListNode[] Next { get; set; }

        public T? Key { get; }

        public SkipListNode(T? key, int level)
        {
            Key = key;     
            Next = new SkipListNode[level];
        }
    }

    static readonly int _maxLevel = 33;
    static readonly Random random = new();

    int _currentMaxLevel = 1;
    SkipListNode _head = new(default, _maxLevel);


    public bool Contains(T value)
    {
        SkipListNode currentNode = _head;
        for (var level = _maxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Key) < 0)
                {
                    break;
                }
                if (value.CompareTo(currentNode.Next[level].Key) == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

}

