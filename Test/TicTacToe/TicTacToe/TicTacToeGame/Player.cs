namespace TicTacToeGame;

/// <summary>
/// Class representing player of TicTacToe game.
/// </summary>
public class Player
{
    /// <summary>
    /// How we mark his move on field.
    /// </summary>
    public string Sign { get; }

    /// <summary>
    /// Player number
    /// </summary>
    public int Number { get; }

    public static Player First { get; } = new Player("x", 1);
    public static Player Second { get; } = new Player("o", 2);

    private Player(string sign, int number)
    {
        Sign = sign;
        Number = number;
    }
}
