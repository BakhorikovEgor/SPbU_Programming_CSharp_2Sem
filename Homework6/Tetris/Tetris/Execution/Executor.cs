using Tetris.Realization;

namespace Tetris.Execution;

public class Executor
{

    private EventLoop eventLoop = new EventLoop();

    private GamePrinter printer;

    private readonly Game game;

    private const int StandardFieldXPosition = 3;
    private const int StandardFieldYPosition = 3;

    private const int StandardFieldLength = 15;
    private const int StandardFieldWidth = 10;

    public Executor() : this(StandardFieldLength, StandardFieldWidth) { }
    public Executor( int fieldLength, int fieldWidth)
    {
        game = AreFieldSizeValid(fieldLength, fieldWidth) 
            ? new Game(fieldLength, fieldWidth) 
            : new Game(StandardFieldLength, StandardFieldWidth);

        printer = new GamePrinter(game, StandardFieldXPosition, StandardFieldYPosition);

    }


    public void Execute()
    {
        printer.PrintWalls();

        eventLoop.GameFieldChangeHandler += printer.Print;

        eventLoop.RotateHandler += game.RotateBlock;

        eventLoop.LeftHandler += game.MoveLeft;

        eventLoop.RightHandler += game.MoveRight;

        eventLoop.DownHandler += game.MoveDown;

        eventLoop.EnterHandler += game.Reset;

        eventLoop.Run();
    }


    private bool AreFieldSizeValid(int length, int width)
        => length < 100 && width < 100;
}
