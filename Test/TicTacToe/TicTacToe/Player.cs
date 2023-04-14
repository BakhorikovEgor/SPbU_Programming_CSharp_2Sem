namespace TicTacToe;

internal class Player
{
    public string Sign { get; }

    public static Player First { get; } = new Player("x");
    public static Player Second { get; } = new Player("o");

    private Player(string sign) => Sign = sign;
}
