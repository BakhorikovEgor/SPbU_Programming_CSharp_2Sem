namespace Tetris.Realization;

public class Game
{
    public bool[,] Grid { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    private readonly (int, int) spawningPosition;
    private Block currentBlock;

    public Game(int length, int width)
    {
        Grid = new bool[length, width];
        spawningPosition = (width / 2, 0);

        currentBlock = CreateCurrentBlock();
    }
    
    public void RotateBlock(object? sender, EventArgs args)
    {
        UpdateField(false);

        Block tempBlock = currentBlock.Rotate();
        if (IsBlockBetween(tempBlock))
        {
            currentBlock = tempBlock;
            UpdateField();
            UpdateGameSituation();
        }
    }

    public void MoveDown(object? sender, EventArgs args)
        => MoveCurrentBlock((0, 1));

    public void MoveRight(object? sender, EventArgs args)
        => MoveCurrentBlock((1, 0));

    public void MoveLeft(object? sender, EventArgs args)
        => MoveCurrentBlock((-1, 0));

    private void MoveCurrentBlock((int, int) shift)
    {
        UpdateField(false);

        Block tempBlock = currentBlock.UpdateComponents(shift);
        if (IsBlockBetween(tempBlock))
        {
            currentBlock = tempBlock;
            UpdateField();
            UpdateGameSituation();
        }
    }


    private Block CreateCurrentBlock()
    {
        Block tempBlock = Block.GenerateBlock().UpdateComponents(spawningPosition);
        if (!IsBlockBetween(tempBlock))
        {
            throw new Exception();
        }

        return tempBlock;
    }

    private bool IsBlockBetween(Block block)
        => block.Components.All(component => component.Item1 >= 0 && component.Item1 < Grid.GetLength(0));

    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item2 < 0);

    private bool IsFreeSpaceUnderCurrentBlock(Block block)
    {
        foreach (var component in block.Components)
        {
            int x = component.Item1;
            int y = component.Item2;

            if (y + 1 >= 0 && Grid[x, y + 1])
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

    private void UpdateGameSituation()
    {
        if (!IsFreeSpaceUnderCurrentBlock(currentBlock))
        {
            if (IsBlockAbove(currentBlock))
            {
                IsGameOver = true;
            }
            else
            {
                currentBlock = CreateCurrentBlock();
            }
        }
    }


}
