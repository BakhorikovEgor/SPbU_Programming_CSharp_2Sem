namespace TicTacToe;
internal class Player
{
    public string Sign { get; }

    public int Number { get; }
    public static Player First { get; } = new Player("x", 1);
    public static Player Second { get; } = new Player("o", 2);

    private Player(string sign, int number)
    {
        Sign = sign;
        Number = number;
    }
}
