using Tetris.Realization;

namespace Tetris.Execution;

public class Executor
{

    private EventLoop eventLoop = new EventLoop();

    private readonly Game game;

    private const int StandardFieldLength = 30;
    private const int StandardFieldWidth = 30;

    public Executor() : this(StandardFieldLength, StandardFieldWidth) { }
    public Executor(int length, int width)
    {
        game = AreFieldSizeValid(length, width) 
            ? new Game(length, width) 
            : new Game(StandardFieldLength, StandardFieldWidth);

    }


    public void Execute()
    {
        eventLoop.RotateHandler += game.RotateBlock;

        eventLoop.LeftHandler += game.MoveLeft;

        eventLoop.RightHandler += game.MoveRight;

        eventLoop.DownHandler += game.MoveDown;

        eventLoop.Run();
    }


    private bool AreFieldSizeValid(int length, int width)
        => length < StandardFieldLength || width < StandardFieldWidth;
}
