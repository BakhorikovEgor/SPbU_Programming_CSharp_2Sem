namespace Tetris.Realization;
internal static class BlockCreator
{
    private static readonly (int, int)[][] BLOCKS = new (int, int)[][]
    {
        new(int, int)[] { (0, 0), (0, 1), (0, 2), (-1 ,2) },
        new(int, int)[] { (0, 0), (0, 1), (0, 2) , (0, 3) },
        new(int, int)[] { (0, 0), (0, 1), (1, 0), (1 ,1) },
        new(int, int)[] { (0, 0), (0, 1), (0, 2), (1 ,2) },
        new(int, int)[] { (0, 0), (0, 1), (1, 1), (2 ,1) },
        new(int, int)[] { (0, 0), (1, 0), (1, -1), (2 ,-1) },
        new(int, int)[] { (0, 0), (1, 0), (1, -1), (2, 0)}
    };

    private static readonly Random random = new();

    public static (int, int)[] CreateBlock(int x, int y)
        => BLOCKS[random.Next(0, BLOCKS.Length)].Select(point => (point.Item1 + x, point.Item2 + y)).ToArray();
}

