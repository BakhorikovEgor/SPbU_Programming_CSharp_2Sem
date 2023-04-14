namespace TicTacToe;

internal class Game
{
    public bool IsGameOver { get; private set; } = false;

    public bool Draw { get; private set; } = false;

    private int[,] field = new int[3, 3];

    public Player movedPlayer = Player.Second;

    private int freeCells = 9;

    public void Move((uint, uint) position)
    {
        if(!IsPositionValid(position))
        {
            throw new ArgumentException("Wrong position for this field !");
        }

        if (IsGameOver || field[position.Item1, position.Item2] != 0) return;

        movedPlayer = movedPlayer == Player.First ? Player.Second : Player.First;
        field[position.Item1, position.Item2] = movedPlayer.Number;
        freeCells--;


        ChangeGameState();


    }

    private void ChangeGameState()
    {
        for (var i = 0; i < 3; ++i)
        {
            if (field[i, 0] != 0 && field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] ||
                (field[0, i] != 0 && field[0, i] == field[1, i] &&  field[1, i] == field[2, i]))
            {
                IsGameOver = true;
            }
        }

        if (field[0,0] != 0 && field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] ||
            field[0,2] != 0 && field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0])
        {
            IsGameOver = true;
        }

        if (freeCells <= 0)
        {
            IsGameOver = true;
            Draw = true;
        }
    }

    private bool IsPositionValid((uint, uint) position)
        => position.Item1 < 3 && position.Item2 < 3;
}
