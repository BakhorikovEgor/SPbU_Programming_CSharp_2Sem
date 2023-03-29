namespace ParsingTree.Utils;


/// <summary>
/// Element of parsing tree, only with integer value.
/// </summary>
public class NumberElement : IParsingTreeElement
{
    public int Value { get; private set; }

    public NumberElement(int value) => Value = value;

    /// <inheritdoc/>
    public double Calculate() => Value;

    /// <inheritdoc/>
    public override string ToString() => Value.ToString();
}
