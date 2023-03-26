using ParsingTree.Utils;


namespace ParsingTree;


internal class Tree
{
    private readonly IParsingTreeElement top;

    public Tree(string expression)
    {
        var expressionParts = expression.Replace(")", "").Replace("(", "").Split(" ");
        var pointer = 0;

        top = GetTreeElement(expressionParts[pointer++]);  
        if (top is OperationElement)
        {
            BuildTree(top, expressionParts, ref pointer);
        }
        else if (expressionParts.Length > 1)
        {
            throw new InvalidDataException();
        }
    }

    private IParsingTreeElement GetTreeElement(string value)
    {
        if (int.TryParse(value, out var number))
        {
            return new NumberElement(number);
        }
        return new OperationElement(value);
    }

    private void BuildTree(IParsingTreeElement currentVertex, string[] expressionParts, ref int pointer)
    {
        if (currentVertex is NumberElement)
        {
            return;
        }

        if (pointer >= expressionParts.Length)
        {
            throw new InvalidDataException();
        }
        OperationElement operation = currentVertex as OperationElement ?? throw new ArgumentException();

        IParsingTreeElement firstChild = GetTreeElement(expressionParts[pointer++]);
        if (firstChild is OperationElement)
        {
            BuildTree(firstChild, expressionParts, ref pointer);
        }
        operation.FirstOperand = firstChild;

        IParsingTreeElement secondChild = GetTreeElement(expressionParts[pointer++]);
        if (secondChild is OperationElement)
        {
            BuildTree(secondChild, expressionParts, ref pointer);
        }
        operation.SecondOperand = secondChild;
    }

    public override string ToString() => top.ToString();

    public double Calculate() => top.Calculate();
}
