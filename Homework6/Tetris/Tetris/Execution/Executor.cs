﻿using Tetris.Print;
using Tetris.Realization;

namespace Tetris.Execution;

/// <summary>
/// Class for executing Tetris game.
/// </summary>
public class Executor
{
    private EventLoop _eventLoop = new EventLoop();

    private GamePrinter _printer;

    private readonly Game _game;

    private const int StandardFieldLength = 20;
    private const int StandardFieldWidth = 10;

    /// <summary>
    /// Standard constructor of Executor.
    /// Creates game and console printer.
    /// </summary>
    public Executor()
    {
        _game = new Game(StandardFieldLength, StandardFieldWidth);
        _printer = new GamePrinter(_game);
    }

    /// <summary>
    /// Executes game.
    /// </summary>
    public void Execute()
    {
        _eventLoop.RotateHandler += _game.Rotate;

        _eventLoop.LeftHandler += _game.MoveLeft;

        _eventLoop.RightHandler += _game.MoveRight;

        _eventLoop.DownHandler += _game.MoveDown;

        _eventLoop.EnterHandler += _game.Reset;

        _eventLoop.SpaceHandler += _game.ChangeGamePauseState;

        _eventLoop.EscapeHandler += Finish;

        _eventLoop.GameUpdateHandler += _printer.Print;
        _eventLoop.GameUpdateHandler += _game.MoveDown;
        _eventLoop.GameUpdateHandler += _game.Sleep;

        _eventLoop.Run();
    }

    private void Finish(object? sender, EventArgs eventArgs)
    {
        _eventLoop.GameUpdateHandler -= _printer.Print;

        _eventLoop.RotateHandler -= _game.Rotate;

        _eventLoop.LeftHandler -= _game.MoveLeft;

        _eventLoop.RightHandler -= _game.MoveRight;

        _eventLoop.DownHandler -= _game.MoveDown;

        _eventLoop.EnterHandler -= _game.Reset;

        _eventLoop.EscapeHandler -= Finish;

        _eventLoop.GameUpdateHandler -= _printer.Print;
        _eventLoop.GameUpdateHandler -= _game.MoveDown;
        _eventLoop.GameUpdateHandler -= _game.Sleep;
    }
}