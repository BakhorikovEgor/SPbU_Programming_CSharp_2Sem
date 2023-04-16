using Tetris.Realization;

namespace Tetris.Execution;

public class Executor
{
    private EventLoop eventLoop = new EventLoop();

    private GamePrinter printer;

    private readonly Game game;


    private const int StandardFieldLength = 20;
    private const int StandardFieldWidth = 10;

    public Executor() : this(StandardFieldLength, StandardFieldWidth) { }
    public Executor( int fieldLength, int fieldWidth)
    {
        Console.SetWindowSize(50,50);
        game = AreFieldSizeValid(fieldLength, fieldWidth) 
            ? new Game(fieldLength, fieldWidth) 
            : new Game(StandardFieldLength, StandardFieldWidth);

        printer = new GamePrinter(game);

    }


    public void Execute()
    {
        eventLoop.GameFieldUpdateHandler += printer.Print;

        eventLoop.RotateHandler += game.Rotate;

        eventLoop.LeftHandler += game.MoveLeft;

        eventLoop.RightHandler += game.MoveRight;

        eventLoop.DownHandler += game.MoveDown;

        eventLoop.EnterHandler += game.Reset;

        eventLoop.GamePauseHadler += game.Sleep;

        eventLoop.Run();
    }


    private bool AreFieldSizeValid(int length, int width)
        => length < 100 && width < 100;
}
