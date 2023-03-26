using ParsingTree.Utils;


namespace ParsingTree;


internal class Tree
{
    private readonly IParsingTreeElement top;

    public Tree(string data)
    {
        var dataArguments = data.Replace(")", "").Replace("(", "").Split(" ");
        int pointer = 0;

        top = GetTreeElement(dataArguments[pointer++]);  
        if (top is OperationElement)
        {
            BuildTree(top, dataArguments, ref pointer);
        }
        else if (dataArguments.Length > 1)
        {
            throw new InvalidDataException();
        }
    }

    private IParsingTreeElement GetTreeElement(string value)
    {
        if (int.TryParse(value, out int number))
        {
            return new NumberElement(number);
        }
        return new OperationElement(value);
    }
    private void BuildTree(IParsingTreeElement currentVertex, string[] dataArguments,ref int pointer)
    {
        if (currentVertex is NumberElement)
        {
            return;
        }

        if (pointer >= dataArguments.Length)
        {
            throw new InvalidDataException();
        }
        OperationElement operation = currentVertex as OperationElement ?? throw new ArgumentException();

        IParsingTreeElement firstChild = GetTreeElement(dataArguments[pointer++]);
        if (firstChild is OperationElement)
        {
            BuildTree(firstChild, dataArguments, ref pointer);
        }
        operation.FirstOperand = firstChild;

        IParsingTreeElement secondChild = GetTreeElement(dataArguments[pointer++]);
        if (secondChild is OperationElement)
        {
            BuildTree(secondChild, dataArguments, ref pointer);
        }
        operation.SecondOperand = secondChild;
    }

    public override string ToString() => top.ToString();

    public double Calculate() => top.Calculate();
}
