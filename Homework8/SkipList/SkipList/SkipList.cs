﻿using System.Collections;

namespace SkipListRealization;

public class SkipList<T> where T : IComparable<T>
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

    static readonly float _newLevelChance = 0.5f;
    static readonly int _maxLevel = 33;
    static readonly Random _rand = new();

    int _currentMaxLevel = 1;
    SkipListNode _head = new(default, _maxLevel);

    public bool Contains(T value)
    {
        SkipListNode currentNode = _head;
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

        SkipListNode currentNode = _head;
        for (var level = _currentMaxLevel - 1; level >= 0; level--)
        {
            while (currentNode.Next[level] != null)
            {
                if (value.CompareTo(currentNode.Next[level].Value) < 0)
                {
                    break;
                }
            }

            if (level < newNodeLevel)
            {
                newNode.Next[level] = currentNode.Next[level];
                currentNode.Next[level] = newNode;
            }
        }
    }

    public bool Remove(T value)
    {
        var result = false;
        SkipListNode currentNode = _head;
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
                    result = true;
                    break;
                }

                currentNode = currentNode.Next[level];
            }
        }
        return result;
    }

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

}

