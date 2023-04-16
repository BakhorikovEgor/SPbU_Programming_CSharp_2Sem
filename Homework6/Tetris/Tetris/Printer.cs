using static System.Console;
using Tetris.Realization;

namespace Tetris;

public class GamePrinter
{
    private Game _game;

    private const int XIndent = 4;
    private const int YIndent = 4;
    public GamePrinter(Game game)
    {
        OutputEncoding = System.Text.Encoding.Unicode;
        _game = game;
    }

    public void Print(object? sender, EventArgs args)
    {
        PrintWalls();
        PrintField();
        PrintGameInfo();
        PrintGameOver();

        SetCursorPosition(0, 2 * XIndent + _game.Field.GetLength(0));
    }

    private void PrintGameInfo()
    {
        ForegroundColor = ConsoleColor.DarkGray;

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent - 1 );
        WriteLine($"Score: {_game.Info.Score}");

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent + 2);
        WriteLine($"Level: {_game.Info.Level}");

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent + 5);
        WriteLine($"Cleans: {_game.Info.Cleans}\n");
    }
    private void PrintWalls()
    {
        ForegroundColor = ConsoleColor.Gray;
        for (int column = XIndent; column < _game.Field.GetLength(1) + XIndent; ++column)
        {
            SetCursorPosition(column, YIndent - 1);
            Write("▢");

            SetCursorPosition(column, YIndent + _game.Field.GetLength(0));
            Write("▢");
        }

        for (int row = YIndent - 1; row <= _game.Field.GetLength(0) + YIndent; ++row)
        {
            SetCursorPosition(XIndent - 1, row);
            Write("▢");

            SetCursorPosition(XIndent + _game.Field.GetLength(1), row);
            Write("▢");
        }
        WriteLine();
    }

    private void PrintField()
    {
        for (int row = 0; row < _game.Field.GetLength(0); ++row)
        {
            for (int column = 0; column < _game.Field.GetLength(1); ++column)
            {
                SetCursorPosition(XIndent + column, YIndent + row);
                if (_game.Field[row, column] != ConsoleColor.White)
                {
                    ForegroundColor = _game.Field[row, column];
                    Write("▢");
                }
                else
                {
                    Write(" ");
                }
            }
        }
    }

    private void PrintGameOver()
    {
        if (_game.IsGameOver)
        {
            SetCursorPosition(XIndent, YIndent - 4);
            ForegroundColor = ConsoleColor.Yellow;

            WriteLine("Game Over!");
            WriteLine("Press Enter to play again");
        }
    }
    
}
