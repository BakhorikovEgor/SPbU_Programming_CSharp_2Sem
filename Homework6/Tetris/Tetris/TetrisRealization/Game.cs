namespace Tetris.Realization;

public class Game
{
    public int[,] Field { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    private readonly (int, int) spawningPosition;
    private Block? currentBlock;

    public Game(int length, int width)
    {
        Field = new int[length, width];
        spawningPosition = (width / 2, 0);

        CreateCurrentBlock();
    }
    
    public void Reset(object? sender, EventArgs args)
    {
        if (IsGameOver)
        {
            Field = new int[Field.GetLength(0), Field.GetLength(1)];
            IsGameOver = false;
            CreateCurrentBlock();
        }
    }

    public void RotateBlock(object? sender, EventArgs args)
        => TryChangeCurrentBlockTo(currentBlock.Rotate());

    public void MoveDown(object? sender, EventArgs args)
        => MoveCurrentBlock((0, 1));

    public void MoveRight(object? sender, EventArgs args)
        => MoveCurrentBlock((1, 0));

    public void MoveLeft(object? sender, EventArgs args)
        => MoveCurrentBlock((-1, 0));

    private void MoveCurrentBlock((int, int) shift) 
        => TryChangeCurrentBlockTo(currentBlock.UpdateComponents(shift));


    private void CreateCurrentBlock()
    {
        currentBlock = Block.GenerateBlock();
        MoveCurrentBlock(spawningPosition);
    }

    private bool IsBlockBetween(Block block)
        => block.Components.All(component => component.Item1 >= 0 && component.Item1 < Field.GetLength(1));

    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item2 <= 0);

    private bool IsPlaceEmptyAndInside(Block block)
    {
        foreach (var component in block.Components)
        {
            int x = component.Item1;
            int y = component.Item2;

            if (y >= Field.GetLength(0) || 
               (y >= 0 && Field[y, x] > 0))
            {
                return false;
            }
        }
        return true;
    }

    private void UpdateCurrentBlockOnField(bool deleting = false)
    {
        var validParts = currentBlock.Components.Where((component) => component.Item2 >= 0);
        foreach (var part in validParts)
        {
            if (!deleting && Field[part.Item2, part.Item1] == 0)
            {
                Field[part.Item2, part.Item1]++;
            }
            else if (deleting && Field[part.Item2, part.Item1] != 0)
            {
                Field[part.Item2, part.Item1]--;
            }
        }
    }
    private void TryChangeCurrentBlockTo(Block block)
    {
        if (!IsGameOver && IsBlockBetween(block))
        {
            UpdateCurrentBlockOnField(true);
            if (IsPlaceEmptyAndInside(block))
            {
                currentBlock = block;
                UpdateCurrentBlockOnField();
            }
            else if (IsBlockAbove(block))
            {
                currentBlock = block;
                UpdateCurrentBlockOnField();

                IsGameOver = true;
            }
            else
            {
                UpdateCurrentBlockOnField();

                DeleteFilledRows();

                CreateCurrentBlock();
            }
        }
    }

    private void DeleteFilledRows()
    {
        for (int row = Field.GetLength(0) - 1; row >= 0; --row)
        {
            int sum = 0;
            for (int column = Field.GetLength(1) - 1; column >= 0; --column)
            {
                sum += Field[row, column];
            }

            if (sum == Field.GetLength(1))
            {
                DeleteRow(row);
            }
        }
    }

    private void DeleteRow(int deletingRow)
    {
        for (int row = deletingRow; row > 0; --row)
        {
            for (int column = 0; column < Field.GetLength(1); ++column)
            {
                Field[row, column] = Field[row - 1, column];
            }
        }

        for (int column = 0; column < Field.GetLength(1); ++column)
        {
            Field[0, column] = 0;
        }
    }
}
