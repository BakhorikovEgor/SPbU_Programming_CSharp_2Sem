namespace Tetris.Realization;

public class Field
{
    public bool[,] Grid { get; private set; }

    public bool IsCurrentBlockMovable { get; private set; } = false;

    public bool IsGridValid { get; private set; } = true;

    private readonly (int, int) spawningPosition;
    private Block? currentBlock;

    public Field(int length, int width)
    {
        Grid = new bool[length, width];
        spawningPosition = (width / 2, 0);

        AddBlock();
    }

    public void Clear()
    {
        
    }


    public void RotateBlock(object? sender, EventArgs args)
    {
        if (!IsGridValid)
        {
            throw new Exception();
        }
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

    public void MoveDown(object? sender, EventArgs args)
        => MoveBlock((0, 1));

    public void MoveRight(object? sender, EventArgs args)
        => MoveBlock((1, 0));

    public void MoveLeft(object? sender, EventArgs args)
        => MoveBlock((-1, 0));

    private void MoveBlock((int, int) shift)
    {
        if (!IsGridValid)
        {
            throw new Exception();
        }

        if (currentBlock == null)
        {
            throw new Exception();
        }

        if (!IsCurrentBlockMovable)
        {
            return;
        }

        UpdateField(false);

        currentBlock = currentBlock.UpdateComponents(shift);
        if (IsBlockValid(currentBlock))
        {
            UpdateField();
        }
        else
        {
            IsCurrentBlockMovable = false;
            if (currentBlock.Components.Any((component) => component.Item2 < 0))
            {
                IsGridValid = false;
            }
            else
            {
                AddBlock();
            }
        }

    }

    private void AddBlock()
    {
        if (!IsGridValid)
        {
            throw new Exception();
        }
        currentBlock = Block.GenerateBlock();

        if (!IsBlockValid(currentBlock))
        {
            throw new Exception();
        }

        IsCurrentBlockMovable = true;
        MoveBlock(spawningPosition);

    }

    private bool IsBlockValid(Block block)
    {
        foreach (var component in block.Components) 
        {
            int x = component.Item1;
            int y = component.Item2;

            if (x < 0 || x > Grid.GetLength(1) - 1 || y > Grid.GetLength(0) - 1)
            {
                return false;
            }

            if (y < 0) continue;

            if (Grid[component.Item1, component.Item2])
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
