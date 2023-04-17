namespace Tetris.Realization;

public class Game
{
    public static ConsoleColor EmptyPlaceMark { get; } = ConsoleColor.White;

    private readonly (int, int) _spawningPosition;
    private Block _currentBlock;

    private enum Moves
    {
        Down, 
        Left, 
        Right,
        Rotate
    }

    public GameStatistics Statistics { get; private set; }

    public ConsoleColor[,] Field { get; private set; }

    public int Length { get; private set; }

    public int Width { get; private set; }

    public bool IsGameOver { get; private set; } = false;

    public bool IsGamePaused { get; private set; } = false;

    public Game(int length, int width)
    {
        (Length, Width) = (length, width);
        Field = new ConsoleColor[length, width];
        Statistics = new(400 + 10 * ((length - 20 + width - 10) / 5));

        _spawningPosition = (0, width / 2);
        _currentBlock = GenerateCurrentBlock();

        InitializeField();
        UpdateCurrentBlockOnField();
    }
    
    public void MoveDown(object? sender, EventArgs args)
        => Move(Moves.Down);

    public void MoveLeft(object? sender, EventArgs args)
        => Move(Moves.Left);

    public void MoveRight(object? sender, EventArgs args)
        => Move(Moves.Right);

    public void Rotate(object? sender, EventArgs args)
        => Move(Moves.Rotate);

    public void Reset(object? sender, EventArgs args)
    {
        if (IsGamePaused) return;

        Field = new ConsoleColor[Length, Width];
        Statistics = new(400 + 10 * ((Length - 20 + Width - 10) / 5));
        IsGameOver = false;
        IsGamePaused = false;

        _currentBlock = GenerateCurrentBlock();

        InitializeField();
        UpdateCurrentBlockOnField();
    }

    public void Sleep(object? sender, EventArgs eventArgs) 
        => Thread.Sleep(Statistics.SleepTime >= 50 
                                            ? Statistics.SleepTime 
                                            : 50);

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

    private bool IsBlockInside(Block block)
        => block.Components.All(component => component.Item2 >= 0 && component.Item2 < Width &&
                                             component.Item1 >= 0 && component.Item1 < Length);

    private bool IsBlockAbove(Block block)
        => block.Components.Any(component => component.Item1 <= 1);

    private bool IsPlaceFree(Block block)
        => block.Components.All(component => Field[component.Item1, component.Item2] == EmptyPlaceMark);

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
