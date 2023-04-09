using static System.Console;

namespace Tetris.Realization;

public class Executor
{

    public void Run(int length, int width)
    {
        Field field = new Field(length, width);
        var processing = true;
        
        field.AddCurrentBlock();
        field.MoveCurrentBlock((0, 1));
        field.RotateCurrentBlock();
        field.MoveCurrentBlock((0, 1));
    }
}
