namespace ParsingTree.Utils;

/// <summary>
/// Class representing element of parsing tree
/// </summary>
internal interface IParsingTreeElement
{
    /// <summary>
    /// Calculate value of element in parsing tree.
    /// </summary>
    double Calculate();

    /// <inheritdoc/>
    string ToString();
}
