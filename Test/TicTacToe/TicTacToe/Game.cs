namespace TicTacToe;

internal class Game
{
    public bool IsGameOver { get; private set; } = false;

    private bool[,] field = new bool[3, 3];

    public Player movedPlayer = Player.Second;

    private int freeCells = 9;
    public void Move((uint, uint) position)
    {
        if(!IsPositionValid(position))
        {
            throw new ArgumentException();
        }

        if (field[position.Item1, position.Item2]) return;

        field[position.Item1, position.Item2] = true;
        freeCells--;

        ChangeGameState();

        if (!IsGameOver)
        {
            movedPlayer = movedPlayer == Player.First ? Player.Second : Player.First;
        }
    }

    private void ChangeGameState()
    {
        if (freeCells <= 0)
        {
            IsGameOver = true;
        }
        else
        {
            for (var i = 0; i < 3; ++i)
            {
                if (field[i, 0] && field[i, 1] && field[i, 2] ||
                   (field[0, i] && field[1, i] && field[2, i]))
                {
                    IsGameOver = true;
                }
            }

            if (field[0, 0] && field[1, 1] && field[2, 2] ||
                field[0, 2] && field[1, 1] && field[2, 0])
            {
                IsGameOver = true;
            }
        }
    }

    private bool IsPositionValid((uint, uint) position)
        => position.Item1 < 3 && position.Item2 < 3;
}
