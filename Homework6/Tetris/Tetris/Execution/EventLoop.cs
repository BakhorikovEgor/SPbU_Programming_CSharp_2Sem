using static System.Console;

namespace Tetris.Execution;

/// <summary>
/// Keyboard event reader.
/// </summary>
public class EventLoop
{
    public event EventHandler<EventArgs> RotateHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> RightHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> LeftHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> DownHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> EnterHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> SpaceHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> EscapeHandler = (sender, eventArgs) => { };

    public event EventHandler<EventArgs> GameUpdateHandler = (sender, eventArgs) => { };

    /// <summary>
    /// Main loop.
    /// Reading pressed keys from keyboard.
    /// </summary>
    public void Run()
    {
        var processing = true;
        while (processing)
        {
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

                    case ConsoleKey.Spacebar:
                        SpaceHandler(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.Escape:
                        EscapeHandler(this, EventArgs.Empty);
                        processing = false;
                        break;
                }

                while (KeyAvailable)
                {
                    ReadKey(true);
                }
            }
            GameUpdateHandler(this, EventArgs.Empty);
        }
    }
}
