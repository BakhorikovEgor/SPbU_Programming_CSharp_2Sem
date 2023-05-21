namespace Tetris.Realization;

/// <summary>
/// The class representing the realization of computer game Tetris.
/// </summary>
public class Game
{
    private readonly (int, int) _spawningPosition;
    private Block _currentBlock;

    private enum Moves
    {
        Down,
        Left,
        Right,
        Rotate
    }

    /// <summary>
    /// How we mark empty place on game field.
    /// </summary>
    public static ConsoleColor EmptyPlaceMark { get; } = ConsoleColor.White;

    /// <summary>
    /// Statistics of current game.
    /// </summary>
    public GameStatistics Statistics { get; private set; }

    /// <summary>
    /// Place for blocks.
    /// </summary>
    public ConsoleColor[,] Field { get; private set; }

    /// <summary>
    /// Length of game field.
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// Width of game field.
    /// </summary>
    public int Width { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    public bool IsGamePaused { get; private set; } = false;

    /// <summary>
    /// Constructor of Tetris game.
    /// </summary>
    public Game(int length, int width)
    {
        (Length, Width) = (length, width);
        Field = new ConsoleColor[length, width];
        Statistics = new();

        _spawningPosition = (0, width / 2);
        _currentBlock = GenerateCurrentBlock();

        InitializeField();
        UpdateCurrentBlockOnField();
    }

    /// <summary>
    /// Try move current block down if it is possible.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void MoveDown(object? sender, EventArgs args)
        => Move(Moves.Down);

    /// <summary>
    /// Try move current block left if it is possible.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void MoveLeft(object? sender, EventArgs args)
        => Move(Moves.Left);

    /// <summary>
    /// Try move current block right if it is possible.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void MoveRight(object? sender, EventArgs args)
        => Move(Moves.Right);

    /// <summary>
    /// Try rotate current block if it is possible.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void Rotate(object? sender, EventArgs args)
        => Move(Moves.Rotate);

    /// <summary>
    /// Restart current game.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void Reset(object? sender, EventArgs args)
    {
        if (IsGamePaused) return;

        Field = new ConsoleColor[Length, Width];
        Statistics = new();
        IsGameOver = false;
        IsGamePaused = false;

        _currentBlock = GenerateCurrentBlock();

        InitializeField();
        UpdateCurrentBlockOnField();
    }

    /// <summary>
    /// Stop all processes for sleep time.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void Sleep(object? sender, EventArgs eventArgs)
        => Thread.Sleep(Statistics.SleepTime);

    /// <summary>
    /// Pause/Continue game if it is not over.
    /// </summary>
    /// <param name="sender"> Who asks game to do it. </param>
    /// <param name="args"> Additional information. </param>
    public void ChangeGamePauseState(object? sender, EventArgs eventArgs)
        => IsGamePaused = IsGameOver
                        ? IsGamePaused
                        : !IsGamePaused;

    private void Move(Moves move)
    {
        if (IsGamePaused || IsGameOver) return;

        UpdateCurrentBlockOnField(true);

        var tempBlock = move switch
        {
            Moves.Down => _currentBlock.UpdateComponents((1, 0)),
            Moves.Left => _currentBlock.UpdateComponents((0, -1)),
            Moves.Right => _currentBlock.UpdateComponents((0, 1)),
            Moves.Rotate => _currentBlock.Rotate(),
            _ => throw new NotImplementedException()
        };

        if (IsBlockInside(tempBlock) && IsPlaceFree(tempBlock))
        {
            _currentBlock = tempBlock;
            UpdateCurrentBlockOnField();
        }
        else if (move == Moves.Down)
        {
            UpdateCurrentBlockOnField();
            if (IsBlockAbove(tempBlock))
            {
                IsGameOver = true;
            }
            else
            {
                DeleteFilledRows();
                _currentBlock = GenerateCurrentBlock();
                UpdateCurrentBlockOnField();
            }

            Statistics.Score += GameStatistics.StandardBonus;

        }
        else
        {
            UpdateCurrentBlockOnField();
        }
    }

    //Is block between walls of field.
    private bool IsBlockInside(Block block)
        => block.Components.All(component => component.Item2 >= 0 && component.Item2 < Width &&
                                             component.Item1 >= 0 && component.Item1 < Length);

    //Has block part that is higher or on the ceiling of the field.
    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item1 <= 1);

    //Is there any other block
    private bool IsPlaceFree(Block block)
        => block.Components.All(component => Field[component.Item1, component.Item2] == EmptyPlaceMark);

    //Change game field deleting or adding current moving block.
    private void UpdateCurrentBlockOnField(bool deleting = false)
    {
        var validParts = _currentBlock.Components.Where((component) => component.Item1 >= 0);
        foreach (var part in validParts)
        {
            Field[part.Item1, part.Item2] = deleting
                                          ? EmptyPlaceMark
                                          : _currentBlock.Color;
        }
    }

    //Delete full of blocks rows
    private void DeleteFilledRows()
    {
        var bonusCoefficient = 1;
        for (var row = Length - 1; row >= 0; --row)
        {
            var isFullRow = true;
            for (var column = Width - 1; column >= 0; --column)
            {
                if (Field[row, column] == EmptyPlaceMark)
                {
                    isFullRow = false;
                    break;
                }
            }

            if (isFullRow)
            {
                DeleteRow(row);

                Statistics.Score += GameStatistics.LineBonus * bonusCoefficient;
                Statistics.Cleans++;

                bonusCoefficient++;
                row++;
            }
        }
    }

    private void DeleteRow(int deletingRow)
    {
        for (var row = deletingRow; row > 0; --row)
        {
            for (var column = 0; column < Width; ++column)
            {
                Field[row, column] = Field[row - 1, column];
            }
        }

        for (var column = 0; column < Width; ++column)
        {
            Field[0, column] = EmptyPlaceMark;
        }
    }

    private Block GenerateCurrentBlock()
        => Block.GenerateBlock().UpdateComponents(_spawningPosition);

    private void InitializeField()
    {
        for (var row = 0; row < Length; ++row)
        {
            for (var column = 0; column < Width; ++column)
            {
                Field[row, column] = EmptyPlaceMark;
            }
        }
    }
}
