namespace PriorityQueue;

/// <summary>
/// MaxHeap Realization of priority queue
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityQueue<T>
{
    Heap heap = new Heap();

    private class Element
    { 
        public T Value { get; }
        public uint Priority { get; }
        public Element(T value, uint priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    /// <summary>
    /// Put element in queue.
    /// </summary>
    /// <param name="value"> Element value.</param>
    /// <param name="priority"> Element priority. </param>
    public void Enqueue(T value, uint priority)
    {
        var element = new Element(value, priority);
        heap.AddElement(element);

    }

    /// <summary>
    /// Get max priority element from queue.
    /// </summary>
    /// <returns> Max priority element.</returns>
    /// <exception cref="InvalidOperationException"> Take element from empty queue.</exception>
    public T Dequeue()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("can not take element from empty queue.");
        }

        return heap.ExtractMax().Value;
    }


    private class Heap
    {
        List<Element> data = new() {  };

        public int Count { get; private set; } = 0;
        public void AddElement(Element element)
        {
            if (data.Count > Count)
            {
                data[Count] = element;
            }
            else
            {
                data.Add(element);
            }
            Count++;
            SiftUp(Count - 1);
        }

        public Element ExtractMax()
        {
            var result = data[0];

            data[0] = data[Count - 1];
            Count--;

            SiftDown(0);

            return result;
        }

        private void SiftUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            var parent = data[parentIndex];
            var current = data[index];
            if (parent.Priority < current.Priority)
            {
                Swap(index, parentIndex);
                if (index == Count - 1 && index % 2 == 0 && data[index - 1].Priority == data[index].Priority)
                {
                    Swap(index, index - 1);
                    return;
                }
                SiftUp(parentIndex);
            }
        }

        private void SiftDown(int index)
        {
            if (index != 0 && data[index + 1].Priority == data[index].Priority)
            {
                Swap(index, index + 1);
                return;
            }

            var firstChildIndex = (index * 2) + 1;
            var secondChildIndex = (index + 1) * 2;

            if (firstChildIndex >= Count)
            {
                return;
            }

            var current = data[index];
            var chosenIndex  = firstChildIndex;
            if (secondChildIndex < Count && data[secondChildIndex].Priority > data[chosenIndex].Priority)
            {
                chosenIndex = secondChildIndex;
            }
            
            if (current.Priority <= data[chosenIndex].Priority)
            {
                Swap(index, chosenIndex);
                SiftDown(chosenIndex);
            }
        }

        private void Swap(int ind1, int ind2)
        {
            var temp = data[ind1];
            data[ind1] = data[ind2];
            data[ind2] = temp;
        }

    }

}