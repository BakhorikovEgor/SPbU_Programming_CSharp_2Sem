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
        OutputEncoding = System.Text.Encoding.Unicode;
        drawingGame = game;
        xPosition = x;
        yPosition = y;
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
        for (int column = xPosition; column < drawingGame.Field.GetLength(1) + xPosition; ++column)
        {
            SetCursorPosition(column, yPosition - 1);
            Write("─");

            SetCursorPosition(column, yPosition + drawingGame.Field.GetLength(0));
            Write("─");
        }

        for (int row = yPosition; row < drawingGame.Field.GetLength(0) + yPosition; ++row)
        {
            SetCursorPosition(xPosition - 1, row);
            Write("│");

            SetCursorPosition(xPosition + drawingGame.Field.GetLength(1), row);
            Write("│");
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
  
    }
    
}
