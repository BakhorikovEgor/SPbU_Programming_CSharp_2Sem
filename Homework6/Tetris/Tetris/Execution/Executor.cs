using Tetris.Realization;

namespace Tetris.Execution;

public class Executor
{

    private EventLoop eventLoop = new EventLoop();

    private readonly Field field;

    private const int StandardFieldLength = 30;
    private const int StandardFieldWidth = 30;

    public Executor() : this(StandardFieldLength, StandardFieldWidth) { }
    public Executor(int length, int width)
    {
        field = AreFieldSizeValid(length, width) 
            ? new Field(length, width) 
            : new Field(StandardFieldLength, StandardFieldWidth);

    }


    public void Execute()
    {
        eventLoop.RotateHandler += field.RotateBlock;

        eventLoop.LeftHandler += field.MoveLeft;

        eventLoop.RightHandler += field.MoveRight;

        eventLoop.DownHandler += field.MoveDown;

        eventLoop.Run();
    }


    private bool AreFieldSizeValid(int length, int width)
        => length < StandardFieldLength || width < StandardFieldWidth;
}
