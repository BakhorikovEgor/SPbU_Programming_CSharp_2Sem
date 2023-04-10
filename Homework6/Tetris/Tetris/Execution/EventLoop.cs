using static System.Console;


namespace Tetris.Execution;

public class EventLoop
{
    public event EventHandler<EventArgs> RotateHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> RightHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> LeftHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> DownHandler = (sender, eventArgs) => { };

    public void Run()
    {
        while(true) 
        {
            if (KeyAvailable)
            {
                var key = ReadKey().Key;         
                switch (key)
                {
                    case ConsoleKey.W:
                        RotateHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.S:
                        DownHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D:
                        RightHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.A:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                }
            }
            else
            {
                DownHandler(this, EventArgs.Empty);
            }
        }
    }
}
