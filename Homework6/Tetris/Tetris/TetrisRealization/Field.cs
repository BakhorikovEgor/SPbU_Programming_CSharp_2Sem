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

        if (!IsBlockValid(currentBlock))
        {
            throw new Exception();
        }
        MoveCurrentBlock(spawningPosition);
        
    }

    public void MoveCurrentBlock((int, int) shift)
    {
        if (currentBlock == null) throw new Exception();

        UpdateField(false);

        currentBlock = currentBlock.UpdateComponents(shift);

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

        UpdateField(false);

        Block tempBlock = currentBlock.Rotate();

        if (IsBlockValid(tempBlock))
        {
            currentBlock = tempBlock;
            UpdateField();
        }
    }


    private bool IsBlockValid(Block block)
    {
        foreach (var component in block.Components) 
        {
            int x = component.Item1;
            int y = component.Item2;
            if (y < 0)
            {
                continue;
            }
            if (x < 0 || x > Grid.GetLength(1) - 1 ||
                y > Grid.GetLength(0) - 1 ||
                Grid[component.Item1, component.Item2])
            {
                return false;
            }
        }

        return true;
    }

    private void UpdateField(bool value = true)
    {
        var validParts = currentBlock!.Components.Where((component) => component.Item2 >= 0);
        foreach (var part in validParts)
        {
            Grid[part.Item1, part.Item2] = value;
        }
    }


}
