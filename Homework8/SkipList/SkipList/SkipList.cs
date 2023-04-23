using System.Collections;

namespace SkipListRealization;

/// <summary>
/// Skip list data structure implementation
/// </summary>
/// <typeparam name="T"> Type of elements in skip list. </typeparam>
public class SkipList<T> :IList<T> where T : IComparable<T>
{
    static readonly double _newLevelChance = 0.5;
    static readonly int _maxLevel = 33;
    static readonly Random _rand = new();

    internal int version = 0;
    internal SkipListNode head = new(default, _maxLevel);

    int _currentMaxLevel = 1;

    ///<inheritdoc/>
    public int Count { get; private set; }

    ///<inheritdoc/>
    ///<exception cref="WrongSkipListElementException"> Null in skip list. </exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index outside of skip list borders.");
            }

            var currentNode = head;
            for (var i = 0; i <= index; ++i)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value ?? throw new WrongSkipListElementException("Null is not able.");
        }

        set
        {
            throw new NotSupportedException("Skip list is sorted, you can not put something by index !");
        }
    }

    /// <summary>
    /// Skip list element
    /// </summary>
    public class SkipListNode
    {
        /// <summary>
        /// Links to the following items at different levels.
        /// </summary>
        public SkipListNode[] Next { get; set; }

        /// <summary>
        /// Value of current skip list element.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"> Value of current element. </param>
        /// <param name="level"> Level of current element in skip list. </param>
        public SkipListNode(T? value, int level)
        {
            Value = value;
            Next = new SkipListNode[level];
        }
    }

    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        readonly int _version;

        SkipList<T> _skipList;
        SkipListNode _currentNode;
        T? _currentValue;

        internal Enumerator(SkipList<T> skipList)
        {
            _skipList = skipList;
            _currentNode = skipList.head;
            _version = skipList.version;
            _currentValue = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_version != _skipList.version)
            {
                throw new InvalidOperationException();
            }
            if (_currentNode.Next[0] == null)
            {
                _currentNode = _skipList.head;
                _currentValue = default;
                return false;
            }

            _currentNode = _currentNode.Next[0];
            _currentValue = _currentNode.Value;
            return true;
        }

        public T Current => _currentValue!;

        object? IEnumerator.Current
        {
            get
            {
                if (_currentNode.Next == null)
                {
                    throw new InvalidOperationException();
                }
                return Current;
            }
        }

        void IEnumerator.Reset()
        {
            if (_version != _skipList.version)
            {
                throw new InvalidOperationException();
            }

            _currentNode = _skipList.head;
            _currentValue = default;
        }
    }

    ///<inheritdoc/>
    public bool Contains(T value)
    {
        var currentNode = head;
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

    /// <inheritdoc/>
    public void Add(T value)
    {
        var newNodeLevel = RandomLevel();
        var newNode = new SkipListNode(value, newNodeLevel);

        var currentNode = head;
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
        version++;
    }

    /// <inheritdoc/>
    public bool Remove(T value)
    {
        var success = false;
        var currentNode = head;
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

        version++;
        return success ;
    }

    /// <inheritdoc/>
    public int IndexOf(T value)
    {
        var counter = 0;
        var currentNode = head;
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

    /// <inheritdoc/>
    public void Insert(int index, T value)
        => throw new NotSupportedException("Skip list is sorted, you can not put something by index !");

    /// <inheritdoc/>
    public void RemoveAt(int index)
        => Remove(this[index]);

    /// <inheritdoc/>
    public void Clear()
    {
        _currentMaxLevel = 1;

        head = new(default, _maxLevel);
        version++;
        Count = 0;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= Count || 
            array.Length < Count - arrayIndex)
        {
            throw new ArgumentException();
        }

        var currentNode = head;
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

    public Enumerator GetEnumerator()
        => new(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() 
        => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() 
        => ((IEnumerable<T>)this).GetEnumerator();

    int RandomLevel()
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

