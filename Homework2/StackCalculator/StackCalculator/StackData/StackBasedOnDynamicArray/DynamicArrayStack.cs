namespace StackData;

/// <summary>
/// Stack realization by using dynamic array.
/// </summary>
public class DynamicArrayStack : IStack
{
    private List<double> array;
    private int count;

    public DynamicArrayStack()
        => array = new List<double>();

    /// <inheritdoc/>
    public void Push(double value)
    {
        if (count == array.Count)
        {
            array.Add(value);
        }
        else
        {
            array[count] = value;
        }
        count++;
    }

    /// <inheritdoc/>
    public double Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can`t pop from empty stack");
        }

        return array[--count];
    }

    /// <inheritdoc/>
    public bool IsEmpty()
        => count == 0;
}
