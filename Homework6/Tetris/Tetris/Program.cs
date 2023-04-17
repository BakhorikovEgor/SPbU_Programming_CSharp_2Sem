using Tetris.Execution;
using static System.Console;

CursorVisible = false;
ForegroundColor = ConsoleColor.DarkCyan;

var executor = new Executor();

WriteLine (
    """
    It's a console game - Tetris!

    I think everyone knows the rules of the game...

    The scoring system is as follows:
    - the block took its place = 10 points
    - there is a line of blocks = 100 points (each next one will bring 100 more)

    About speed:
    The speed depends on your level, the level depends on the number of points scored.
    Initially, you have 1 level and to go to 2 you need to score 100 points,
    to go to the next levels, the number of points required is doubled.

    Control keys:
    W - rotate block
    A  - move the block to the left if possible
    S  - move the block down if possible
    D  - move the block to the right if possible
    Spacebar  - pause / continue the game
    Enter  - restart the game
    Escape  - exit the game

    Good Luck !

    """);


ForegroundColor = ConsoleColor.Cyan;
WriteLine("Press Enter to start the game");

while (!KeyAvailable || ReadKey(true).Key != ConsoleKey.Enter) ;

Clear();

executor.Execute();