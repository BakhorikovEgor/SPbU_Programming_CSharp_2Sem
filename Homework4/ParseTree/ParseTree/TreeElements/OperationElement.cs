namespace ParsingTree.Utils;


/// <summary>
/// Element of parsing tree representing binary operation.
/// </summary>
internal class OperationElement : IParsingTreeElement
{
    /// <summary>
    /// Type of binary operation.
    /// </summary>
    public string Type { get; private set; }

    public IParsingTreeElement? FirstOperand { private get; set; }
    public IParsingTreeElement? SecondOperand { private get; set; }


    /// <exception cref="ArgumentException"> Type is not an able binary operator. </exception>
    public OperationElement(string type) => Type = "+-*/".Contains(type)
                                                 ? type
                                                 : throw new ArgumentException("Wrong type");

    /// <inheritdoc/>
    public double Calculate()
    {
        if (FirstOperand == null || SecondOperand == null)
        {
            throw new InvalidDataException("Tree expression is not formatted correctly.");
        }
        return BinaryOperation.Solve(Type, FirstOperand.Calculate(), SecondOperand.Calculate());
    }

    public override string ToString() => $"( {Type} {FirstOperand} {SecondOperand} )";
}