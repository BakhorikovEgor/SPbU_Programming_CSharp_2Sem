using System.Collections;

namespace SkipListRealization;

public class SkipList<T> :IList<T> where T : IComparable<T>
{
    class SkipListNode
    {
        public SkipListNode[] Next { get; set; }

        public T? Value { get; }

        public SkipListNode(T? value, int level)
        {
            Value = value;
            Next = new SkipListNode[level];
        }
    }

    static readonly double _newLevelChance = 0.5;
    static readonly int _maxLevel = 33;
    static readonly Random _rand = new();

    int _currentMaxLevel = 1;
    SkipListNode _head = new(default, _maxLevel);

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {   
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException();
            }

            var currentNode = _head;
            for (var i = 0; i <= index; ++i)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value ?? throw new NullReferenceException();
        }

        set
        {
            throw new NotSupportedException();
        }
    }

    public bool Contains(T value)
    {
        var currentNode = _head;
        for (var level = _currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                if (value.CompareTo(currentNode.Next[level].Value) == 0)
                {
                    return true;
                }

                currentNode = currentNode.Next[level];
            }
        }
        return false;
    }

    public void Add(T value)
    {
        var newNodeLevel = RandomLevel();
        var newNode = new SkipListNode(value, newNodeLevel);

        var currentNode = _head;
        for (var level = _currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                currentNode = currentNode.Next[level];
            }

            if (level < newNodeLevel)
            {
                newNode.Next[level] = currentNode.Next[level];
                currentNode.Next[level] = newNode;
            }
        }

        Count++;
    }

    public bool Remove(T value)
    {
        var success = false;
        var currentNode = _head;
        for (var level = _currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
                if (value.CompareTo(currentNode.Next[level].Value) == 0)
                {
                    currentNode.Next[level] = currentNode.Next[level].Next[level];
                    success = true;
                    break;
                }

                currentNode = currentNode.Next[level];
            }
        }

        if (success)
        {
            Count--;
        }
        return success ;
    }

    public int IndexOf(T value)
    {
        var counter = 0;
        var currentNode = _head;
        while (currentNode.Next != null)
        {
            if (value.CompareTo(currentNode.Next[0].Value) == 0)
            {
                return counter;
            }
            counter++;
            currentNode = currentNode.Next[0];
        }
        return -1;
    }

    public void Insert(int index, T value)
        => throw new NotSupportedException();

    public void RemoveAt(int index)
        => Remove(this[index]);

    public void Clear()
    {
        _head = new(default, _maxLevel);
        _currentMaxLevel = 1;
        Count = 0;
    }
    
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || 
            array.Length < Count - arrayIndex)
        {
            throw new ArgumentException();
        }

        var currentNode = _head;
        for (var i = 0; i < arrayIndex; ++i)
        {
            currentNode = currentNode.Next[0];
        }

        for (var i = 0; i < array.Length; ++i)
        {
            array[i] = currentNode.Next[0].Value 
                ?? throw new NullReferenceException();
            currentNode = currentNode.Next[0];
        }
    }

    public IEnumerator GetEnumerator()
    {
        var array = new T[Count];
        CopyTo(array, 0);

        return array.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    => (IEnumerator<T>)GetEnumerator();

    private int RandomLevel()
    {
        var resultLevel = 1;
        while (_rand.NextDouble() < _newLevelChance && resultLevel < _maxLevel)
        {
            resultLevel++;
        }

        _currentMaxLevel = Math.Max(_currentMaxLevel, resultLevel);
        return resultLevel;
    }


    bool ICollection<T>.IsReadOnly => false;
}

