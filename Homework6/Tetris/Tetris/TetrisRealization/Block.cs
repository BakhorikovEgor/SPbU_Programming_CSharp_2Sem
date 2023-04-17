namespace Tetris.Realization;

/// <summary>
/// Realizations of blocks from the Tetris game.
/// </summary>
public class Block
{
    /// <summary>
    /// Coordinates of block in field.
    /// </summary>
    public (int, int)[] Components { get; set; }

    /// <summary>
    /// Color of block in field.
    /// </summary>
    public ConsoleColor Color { get; private set; }

    private static readonly Random random = new();

    /// Blocks of tetris game.
    private static readonly Block[] BLOCKS = new Block[]
    {
        new Block(ConsoleColor.Blue,     (0, 0), (0, 1), (0, 2), (0, 3)),
        new Block(ConsoleColor.DarkBlue, (1, 0), (1, 1), (1, 2), (0, 0)),
        new Block(ConsoleColor.Cyan,     (1, 0), (1, 1), (1, 2), (0, 0)),
        new Block(ConsoleColor.Yellow,   (1, 0), (1, 1), (0, 0), (0, 1)),
        new Block(ConsoleColor.Green,    (1, 1), (1, 0), (0, 1), (0 ,2)),
        new Block(ConsoleColor.Magenta,  (1, 1), (1, 0), (0, 1), (1 ,2)),
        new Block(ConsoleColor.Red,      (1, 1), (1, 2), (0, 0), (0 ,1)),
    };

    private Block(ConsoleColor color, params (int, int)[] components) => (Color, Components) = (color, components);

    /// <summary>
    /// Returns one of the prepared blocks
    /// </summary>
    public static Block GenerateBlock()
        => BLOCKS[random.Next(0, BLOCKS.Length)];

    /// <summary>
    /// Generate new block using old one and coordinates of shift vector.
    /// </summary>
    /// <param name="vector"> Where we want move the block. </param>
    /// <returns> Shifted block. </returns>
    public Block UpdateComponents((int, int) vector)
        => new(Color, Components.Select(component => ComponentSum(component, vector)).ToArray());

    /// <summary>
    /// Rotates the block 90 degrees clockwise around the first coordinate.
    /// </summary>
    /// <returns> Rotated block. </returns>
    public Block Rotate()
    {
        (int, int) shiftVector = (Components[0].Item1 - Components[0].Item2, Components[0].Item2 + Components[0].Item1);

        return new(Color, Components.Select(component => ComponentSum((component.Item2, -component.Item1), shiftVector)).ToArray());
    }

    private static (int, int) ComponentSum((int, int) firstComponent, (int, int) secondComponent)
        => (firstComponent.Item1 + secondComponent.Item1, firstComponent.Item2 + secondComponent.Item2);
}