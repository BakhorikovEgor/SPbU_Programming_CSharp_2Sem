namespace Tetris.Realization;

internal class Block
{
    public (int, int) [] Components { get; set; }

    public ConsoleColor Color { get; private set; }

    private static readonly Random random = new();

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

    public static Block GenerateBlock()
        => BLOCKS[random.Next(0, BLOCKS.Length)];

    public Block UpdateComponents((int, int) shift)
        => new(Color, Components.Select(component => ComponentSum(component, shift)).ToArray());

    public Block Rotate()
    {
        (int, int) shiftVector = (Components[0].Item1 - Components[0].Item2, Components[0].Item2 + Components[0].Item1);

        return new(Color, Components.Select(component => ComponentSum((component.Item2, -component.Item1), shiftVector)).ToArray());
    }

    private static (int, int) ComponentSum((int,int) firstComponent, (int, int) secondComponent)
        => (firstComponent.Item1 + secondComponent.Item1, firstComponent.Item2 + secondComponent.Item2);
}

