namespace Tetris.Realization;

internal class Field
{
    public int[,] Grid { get; private set; }

    private readonly (int, int) spawningPosition;

    private Block? currentBlock;

    public Field(int length, int width)
    {
        Grid = new int[length, width];
        spawningPosition = (width / 2, 0);
    }

    public void AddBlock()
    {
        if (currentBlock == null) throw new Exception();

        currentBlock = Block.GenerateBlock();
        MoveBlock((block, shift) 
            => block.Components
                    .Select(component => (component.Item1 + spawningPosition.Item1, component.Item2 + spawningPosition.Item2)));
    }

    public void MoveBlock(Action<Block, (int, int)> mover)
    {
        if (currentBlock == null) throw new Exception();

        mover(currentBlock);
    }

    private bool IsBlockValid(Block block)
    {
        foreach (var component in block.Components) 
        {
            int x = component.Item1;
            int y = component.Item2;
            if (x < 0 || x > Grid.GetLength(1) - 1 ||
                y < 0 || y > Grid.GetLength(0) - 1 ||
                Grid[component.Item1, component.Item2] > 1)
            {
                return false;
            }
        }

        return true;
    }


}
