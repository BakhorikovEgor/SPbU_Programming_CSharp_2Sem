using Tetris.Realization;

namespace Tetris.Execution;

public class Executor
{
    private EventLoop _eventLoop = new EventLoop();

    private GamePrinter _printer;

    private readonly Game _game;


    private const int StandardFieldLength = 20;
    private const int StandardFieldWidth = 10;

    public Executor() : this(StandardFieldLength, StandardFieldWidth) { }
    public Executor( int fieldLength, int fieldWidth)
    {
        Console.SetWindowSize(50,50);
        _game = AreFieldSizeValid(fieldLength, fieldWidth) 
            ? new Game(fieldLength, fieldWidth) 
            : new Game(StandardFieldLength, StandardFieldWidth);

        _printer = new GamePrinter(_game);

    }


    public void Execute()
    {
        _eventLoop.GameFieldUpdateHandler += _printer.Print;

        _eventLoop.RotateHandler += _game.Rotate;

        _eventLoop.LeftHandler += _game.MoveLeft;

        _eventLoop.RightHandler += _game.MoveRight;

        _eventLoop.DownHandler += _game.MoveDown;

        _eventLoop.EnterHandler += _game.Reset;

        _eventLoop.GamePauseHandler += _game.Sleep;

        _eventLoop.FinishHandler += Finish;

        _eventLoop.Run();
    }

    private void Finish(object? sender, EventArgs eventArgs)
    {
        _eventLoop.GameFieldUpdateHandler -= _printer.Print;

        _eventLoop.RotateHandler -= _game.Rotate;

        _eventLoop.LeftHandler -= _game.MoveLeft;

        _eventLoop.RightHandler -= _game.MoveRight;

        _eventLoop.DownHandler -= _game.MoveDown;

        _eventLoop.EnterHandler -= _game.Reset;

        _eventLoop.GamePauseHandler -= _game.Sleep;

        _eventLoop.FinishHandler -= Finish;
    }


    private bool AreFieldSizeValid(int length, int width)
        => length < 100 && width < 100;
}
