namespace ParsingTree.Utils;

internal class OperationElement: IParsingTreeElement
{
    public string Type { get; private set; }

    public IParsingTreeElement? FirstOperand { private get; set; }
    public IParsingTreeElement? SecondOperand { private get; set; }

    public OperationElement(string type) => Type = "+-*/".Contains(type)
                                                 ? type 
                                                 : throw new ArgumentException();

    public double Calculate() 
    {
        if (FirstOperand == null || SecondOperand == null)
        {
            throw new NullReferenceException();
        } 
        return BinaryOperation.Solve(Type, FirstOperand.Calculate(), SecondOperand.Calculate());
    }

    public override string ToString()
    {
        if (FirstOperand == null)
        {
            throw new NullReferenceException();
        }
        return $"( {Type} {FirstOperand} {SecondOperand} )";
    }
}