using static System.Console;
using Tetris.Realization;

namespace Tetris;

public class GamePrinter
{
    private Game drawingGame;
    private int xPosition;
    private int yPosition;
    public GamePrinter(Game game, int x, int y)
    {
        drawingGame = game;
        xPosition = x;
        yPosition = y;
    }

    public void Print(object? sender, EventArgs args)
    {
        Clear();

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


    public void PrintWalls()
    {
        for (int i = xPosition; i < drawingGame.Field.GetLength(1) + xPosition; ++i)
        {
            SetCursorPosition(i, yPosition - 1);
            Write("-");

            SetCursorPosition(i, yPosition + drawingGame.Field.GetLength(0));
            Write("—");
        }

        for (int i = yPosition; i < drawingGame.Field.GetLength(0) + yPosition; ++i)
        {
            SetCursorPosition(xPosition - 1, i);
            Write("|");

            SetCursorPosition(xPosition + drawingGame.Field.GetLength(1), i);
            Write("|");
        }
    }

    private void PrintField()
    {
        for (int row = 0; row < drawingGame.Field.GetLength(0); ++row)
        {
            for (int column = 0; column < drawingGame.Field.GetLength(1); ++column)
            {
                SetCursorPosition(xPosition + column, yPosition + row);
                if (drawingGame.Field[row, column] == 1)
                {
                    Write("*");
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
        Set
    }
    
}
