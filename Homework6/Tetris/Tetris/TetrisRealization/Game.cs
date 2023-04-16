namespace Tetris.Realization;

public class Game
{
    public int[,] Field { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    public int Score { get; private set; } = 0;

    private readonly (int, int) spawningPosition;
    private Block currentBlock;

    public Game(int length, int width)
    {
        Field = new int[length, width];
        spawningPosition = (0, width / 2);

        currentBlock = Block.GenerateBlock();
        MoveCurrentBlock(spawningPosition);
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
        => MoveCurrentBlock((1, 0));

    public void MoveRight(object? sender, EventArgs args)
        => MoveCurrentBlock((0, 1));

    public void MoveLeft(object? sender, EventArgs args)
        => MoveCurrentBlock((0, -1));

    private void MoveCurrentBlock((int, int) shift) 
        => TryChangeCurrentBlockTo(currentBlock.UpdateComponents(shift));


    private void CreateCurrentBlock()
    {
        currentBlock = Block.GenerateBlock();
        MoveCurrentBlock(spawningPosition);
    }

    private bool IsBlockBetween(Block block)
        => block.Components.All(component => component.Item2 >= 0 && component.Item2 < Field.GetLength(1));

    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item1 <= 0);

    private bool IsPlaceEmptyAndInside(Block block)
    {
        foreach (var component in block.Components)
        {
            int row = component.Item1;
            int column = component.Item2;

            if (row >= Field.GetLength(0) || 
               (column >= 0 && Field[row, column] > 0))
            {
                return false;
            }
        }
        return true;
    }

    private void UpdateCurrentBlockOnField(bool deleting = false)
    {
        var validParts = currentBlock.Components.Where((component) => component.Item1 >= 0);
        foreach (var part in validParts)
        {
            if (!deleting && Field[part.Item1, part.Item2] == 0)
            {
                Field[part.Item1, part.Item2]++;
            }
            else if (deleting && Field[part.Item1, part.Item2] != 0)
            {
                Field[part.Item1, part.Item2]--;
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
                Score++;
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
