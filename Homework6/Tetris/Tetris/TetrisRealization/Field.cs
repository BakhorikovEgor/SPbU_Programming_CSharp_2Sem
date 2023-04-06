namespace Tetris.Realization;

internal class Field
{
    public bool[,] Grid { get; private set; }

    public bool IsMovingBlockExist { get; private set; } = false;

    private readonly (int, int) spawningPosition;

    private Block? currentBlock;
   

    public Field(int length, int width)
    {
        Grid = new bool[length, width];
        spawningPosition = (width / 2, 0);
    }

    public void AddBlock()
    {
        currentBlock = Block.GenerateBlock();
        IsMovingBlockExist = true;

        MoveBlock(spawningPosition);
        
    }

    public void MoveBlock((int, int) shift)
    {
        if (currentBlock == null) throw new Exception();

        Block block = currentBlock.UpdateComponents(shift);
        currentBlock = block;

        if (IsCurrentBlockValid()) UpdateField();
        else IsMovingBlockExist = false;
  
    }

    private bool IsCurrentBlockValid()
    {
        foreach (var component in currentBlock!.Components) 
        {
            int x = component.Item1;
            int y = component.Item2;
            if (x < 0 || x > Grid.GetLength(1) - 1 ||
                y < 0 || y > Grid.GetLength(0) - 1 ||
                Grid[component.Item1, component.Item2])
            {
                return false;
            }
        }

        return true;
    }

    private void UpdateField()
        => Array.ForEach(currentBlock!.Components, component => Grid[component.Item1, component.Item2] = true);

}
