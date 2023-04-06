namespace Tetris.Realization;
internal class Block
{
    public (int, int) [] Components { get; set; }

    private Block(params (int, int)[] components) => Components = components;

    private static readonly Block[] BLOCKS = new Block[]
    {
        new Block((0, 0), (0, 1), (0, 2), (-1 ,2)),
        new Block((0, 0), (0, 1), (0, 2), (0, 3)),
        new Block((0, 0), (0, 1), (1, 0), (1 ,1)),
        new Block((0, 0), (0, 1), (0, 2), (1 ,2)),
        new Block((0, 0), (0, 1), (1, 1), (2 ,1)),
        new Block((0, 0), (1, 0), (1, -1), (2 ,-1)),
        new Block((0, 0), (1, 0), (1, -1), (2, 0))
    };

    private static readonly Random random = new();

    public static Block GenerateBlock()
        => BLOCKS[random.Next(0, BLOCKS.Length)];

    public Block updateComponents((int, int) startPosition)
        => new(Components.Select(component => (component.Item1 + startPosition.Item1, component.Item2 + startPosition.Item2)).ToArray());
    
}

