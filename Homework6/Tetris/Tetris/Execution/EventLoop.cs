using System.Windows.Markup;
using static System.Console;

namespace Tetris.Execution;

public class EventLoop
{
    public event EventHandler<EventArgs> RotateHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> RightHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> LeftHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> DownHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> EnterHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> GameFieldChangeHandler = (sender, eventArgs) => { };

    public void Run()
    {
        while(true) 
        {
            GameFieldChangeHandler(this, EventArgs.Empty);

            if (KeyAvailable)
            {
                var key = ReadKey(true).Key;
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

                    case ConsoleKey.Enter:
                        EnterHandler(this, EventArgs.Empty);
                        break;
                }

                while (KeyAvailable)
                {
                    ReadKey(true);
                }
            }

            DownHandler(this, EventArgs.Empty);

            Thread.Sleep(370);
        }
    }
}
