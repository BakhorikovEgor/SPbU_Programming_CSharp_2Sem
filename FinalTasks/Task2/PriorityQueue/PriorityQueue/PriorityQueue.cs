namespace PriorityQueue;

public class PriorityQueue<T>
{
    Heap heap = new Heap();
    public class Element
    {
        public T Value { get; }
        public uint Priority { get; }

        public Element(T value, uint priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    public void Enqueue(T value, uint priority)
    {
        var element = new Element(value, priority);
        heap.AddElement(element);

    }

    public T Dequeue()
    {
        if (heap.Count() == 0)
        {
            throw new InvalidOperationException();
        }



    }


    private class Heap
    {
        List<Element> data = new();

        public int Count { get; private set; } = 0;
        public void AddElement(Element element)
        {
            data[Count++] = element;
            SiftUp(data.Count - 1);
        }

        public Element ExtractMax()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = data[0];

            data[0] = data[data.Count - 1];
            Count--;

            SiftDown(0);

            return result;
        }

        private void SiftUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = (index - 1) / 2;
            var parent = data[parentIndex];

            var current = data[index];
            if (parent.Priority < current.Priority)
            {
                Swap(index, parentIndex);
                SiftUp(parentIndex);
            }
        }

        private void SiftDown(int index)
        {
            if (index ==  data.Count - 1)
            {
                return;
            }

            var firstChildIndex = (index * 2) + 1;
            var secondChildIndex = (index + 1) * 2;

            var current = data[index];
            var firstChild = data[firstChildIndex];
            var secondChild = data[secondChildIndex];

            if (firstChild.Priority >= secondChild.Priority
                && current.Priority < firstChild.Priority) 
            {
                Swap(index, firstChildIndex);
                SiftDown(firstChildIndex);
            }
            else if (current.Priority < secondChild.Priority)
            {
                Swap(index, secondChildIndex);
                SiftDown(secondChildIndex);
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