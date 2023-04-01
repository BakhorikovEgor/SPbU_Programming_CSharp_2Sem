namespace TetrisRealization;
internal static class BlockCreator
{
    private static readonly (int, int)[][] BLOCKS = new (int, int)[][]
    {
        new(int, int)[] { (0, 0), (0,1), (0, 2), (-1 ,2) },
        new(int,int) [] { (0, 0), (0,1), (0,2) , (0,3) },
        new(int, int)[] { (0, 0), (0,1), (1, 0), (1 ,1) },
        new(int, int)[] { (0, 0), (0, 1), (0, 2), (1 ,2) },
        new(int, int)[] { (0, 0), (0, 1), (1, 1), (2 ,1) },
        new(int, int)[] { (0, 0), (1, 0), (1, -1), (2 ,-1) },
        new(int, int)[] { (0, 0), (1, 0), (1, -1), (2, 0)}
    };

    private static readonly Random random = new Random();

    public static (int, int)[] CreateBlock(int x, int y)
    {
        var block = new List<(int, int)> ();
        foreach (var blockElement in BLOCKS[random.Next(0, BLOCKS.Length)]) 
        {
            block.Add((blockElement.Item1 + x, blockElement.Item2 + y));
        }

        return block.ToArray();
    }
}

