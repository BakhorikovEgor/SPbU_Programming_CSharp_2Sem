namespace Tetris.Realization;

internal class Field
{
    public bool[,] Grid { get; private set; }

    public bool IsMovingBlockExist { get; private set; } = false;

    public bool IsGridValid { get; private set; } = true;

    private readonly (int, int) spawningPosition;

    private Block? currentBlock;
   

    public Field(int length, int width)
    {
        Grid = new bool[length, width];
        spawningPosition = (width / 2, 0);
    }

    public void AddCurrentBlock()
    {
        currentBlock = Block.GenerateBlock();
        IsMovingBlockExist = true;

        MoveCurrentBlock(spawningPosition);
        
    }

    public void MoveCurrentBlock((int, int) shift)
    {
        if (currentBlock == null) throw new Exception();

        Block block = currentBlock.UpdateComponents(shift);
        currentBlock = block;

        if (IsBlockValid(currentBlock))
        {
            UpdateField();
        }

        else
        {
            IsMovingBlockExist = false;
            if (currentBlock.Components.Any((x) => x.Item2 < 0))
            {
                IsGridValid = false;
            }
        }

    }


    public void RotateCurrentBlock()
    {
        if (currentBlock == null)
        {
            throw new Exception();
        }

        Block tempBlock = currentBlock.Rotate();

        if (IsBlockValid(tempBlock))
        {
            currentBlock = tempBlock;
        }
    }


    private bool IsBlockValid(Block block)
    {
        foreach (var component in block.Components) 
        {
            int x = component.Item1;
            int y = component.Item2;
            if (x < 0 || x > Grid.GetLength(1) - 1 ||
                y > Grid.GetLength(0) - 1 ||
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
