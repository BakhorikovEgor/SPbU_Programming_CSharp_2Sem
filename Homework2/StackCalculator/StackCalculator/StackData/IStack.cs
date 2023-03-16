namespace StackData;

/// <summary>
/// Last in First out data structe.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Add element in stack.
    /// </summary>
    /// <param name="value"> Value to add.</param>
    public void Push(double value);

    /// <summary>
    /// Delete element from stack (LIFO rule) if stack isn`t empty.
    /// </summary>
    /// <returns> Dealeating value. </returns>
    /// <exception cref="InvalidOperationException"> Try to pop from empty stack. </exception>
    public double Pop();

    /// <summary>
    /// Check if stack is empty.
    /// </summary>
    public bool IsEmpty();
}
