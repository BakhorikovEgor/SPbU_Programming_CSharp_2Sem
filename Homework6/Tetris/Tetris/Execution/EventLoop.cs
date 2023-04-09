using static System.Console;


namespace Tetris.Execution;

public class EventLoop
{

    public event EventHandler<EventArgs> GameEndingHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> LandingHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> RotateHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> RightShiftHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> LeftShiftHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> DownShiftHandler = (sender, eventArgs) => { };

    public void Run()
    {
        while(true) 
        {
            if (KeyAvailable)
            {
                var key = ReadKey().Key;         
                switch (key)
                {
                    case ConsoleKey.Escape:
                        GameEndingHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.W:
                        RotateHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.S:
                        DownShiftHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D:
                        RightShiftHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.A:
                        LeftShiftHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
