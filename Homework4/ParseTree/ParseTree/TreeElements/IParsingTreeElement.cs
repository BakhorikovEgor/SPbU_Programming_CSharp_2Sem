namespace ParsingTree.Utils;

/// <summary>
/// Class representing element of parsing tree
/// </summary>
public interface IParsingTreeElement
{
    /// <summary>
    /// Calculate value of element in parsing tree.
    /// </summary>
    double Calculate();

    /// <inheritdoc/>
    string ToString();
}
