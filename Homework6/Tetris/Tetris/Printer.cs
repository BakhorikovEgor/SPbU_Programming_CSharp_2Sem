using static System.Console;
using Tetris.Realization;

namespace Tetris;

public class GamePrinter
{
    private Game drawingGame;

    private const int xIndent = 2;
    private const int yIndent = 3;
    public GamePrinter(Game game)
    {
        OutputEncoding = System.Text.Encoding.Unicode;
        drawingGame = game;
    }

    public void Print(object? sender, EventArgs args)
    {
        PrintWalls();

        PrintField();

        if (drawingGame.IsGameOver)
        {
            PrintGameOver();
        }
        else
        {
            
        }
    }


    private void PrintWalls()
    {
        ForegroundColor = ConsoleColor.Red;
        for (int column = xIndent; column < drawingGame.Field.GetLength(1) + xIndent; ++column)
        {
            SetCursorPosition(column, yIndent - 1);
            Write("▢");

            SetCursorPosition(column, yIndent + drawingGame.Field.GetLength(0));
            Write("▢");
        }

        for (int row = yIndent - 1; row <= drawingGame.Field.GetLength(0) + yIndent; ++row)
        {
            SetCursorPosition(xIndent - 1, row);
            Write("▢");

            SetCursorPosition(xIndent + drawingGame.Field.GetLength(1), row);
            Write("▢");
        }
    }

    private void PrintField()
    {
        for (int row = 0; row < drawingGame.Field.GetLength(0); ++row)
        {
            for (int column = 0; column < drawingGame.Field.GetLength(1); ++column)
            {
                SetCursorPosition(xIndent + column, yIndent + row);
                ForegroundColor = drawingGame.Field[row, column];
                if (ForegroundColor != ConsoleColor.White)
                {
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
        SetCursorPosition(0, 0);
        WriteLine("Game Over !");
        WriteLine("Press Enter to play again !");

    }

    private void PrintScore()
    {
  
    }
    
}
