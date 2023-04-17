using static System.Console;
using Tetris.Realization;

namespace Tetris.Print;

public class GamePrinter
{
    private Game _game;

    private const int XIndent = 2;
    private const int YIndent = 2;
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

        SetCursorPosition(0, _game.Length + YIndent + 1);
    }

    private void PrintGameInfo()
    {
        ForegroundColor = ConsoleColor.Gray;

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent - 1 );
        WriteLine($"Score: {_game.Statistics.Score.ToString().PadLeft(8, '0')}");

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent + 2);
        WriteLine($"Level: {_game.Statistics.Level.ToString().PadLeft(3, '0')}");

        SetCursorPosition(XIndent + _game.Field.GetLength(1) + 3, YIndent + 5);
        WriteLine($"Cleans: {_game.Statistics.Cleans.ToString().PadLeft(4, '0')}\n");
    }

    private void PrintWalls()
    {
        ForegroundColor = ConsoleColor.White;

        SetCursorPosition(XIndent - 1, YIndent - 1);
        Write("╔");

        SetCursorPosition(XIndent - 1, YIndent + _game.Length);
        Write("╚");

        SetCursorPosition(XIndent + _game.Width , YIndent - 1);
        Write("╗");

        SetCursorPosition(XIndent + _game.Width, YIndent + _game.Length);
        Write("╝");

        for (int column = XIndent; column < _game.Width + XIndent; ++column)
        {
            SetCursorPosition(column, YIndent - 1);
            Write('═');

            SetCursorPosition(column, YIndent + _game.Length);
            Write('═');
        }

        for (int row = YIndent; row < _game.Length + YIndent; ++row)
        {
            SetCursorPosition(XIndent - 1, row);
            Write("║");

            SetCursorPosition(XIndent + _game.Width, row);
            Write("║");
        }
        WriteLine();
    }

    private void PrintField()
    {
        for (int row = 0; row < _game.Length; ++row)
        {
            for (int column = 0; column < _game.Width; ++column)
            {
                SetCursorPosition(XIndent + column, YIndent + row);
                if (_game.Field[row, column] != Game.EmptyPlaceMark)
                {
                    ForegroundColor = _game.Field[row, column];
                    Write("■");
                }
                else
                {
                    Write(" ");
                }
            }
        }
    }

}
