namespace ParsingTree.Utils;

internal class NumberElement: IParsingTreeElement
{
    public int Value { get; private set; }

    public  NumberElement(int value) => Value = value;

    public double Calculate() => Value;

    public override string ToString() => Value.ToString();
}
