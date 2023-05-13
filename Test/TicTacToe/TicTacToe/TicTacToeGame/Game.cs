namespace TicTacToeGame;

/// <summary>
/// Class representing TicTacToe (3 x 3) game.
/// </summary>
public class Game
{
    // Found three same value in the row
    public bool IsGameOver { get; private set; } = false;

    // No place to move
    public bool Draw { get; private set; } = false;

    // Who made previous move
    public Player MovedPlayer { get; set; } = Player.Second;

    private int[,] field = new int[3, 3];

    private int freeCells = 9;

    /// <summary>
    /// Add user move to field.
    /// </summary>
    /// <param name="position"> Position to mark. </param>
    /// <exception cref="ArgumentException"> Position is valid for current field </exception>
    public void Move((uint Col, uint Row) position)
    {
        if(!IsPositionValid(position))
        {
            throw new ArgumentException("Wrong position for this field !");
        }

        if (IsGameOver || field[position.Item1, position.Item2] != 0) return;

        MovedPlayer = MovedPlayer == Player.First 
                                  ? Player.Second 
                                  : Player.First;
        field[position.Col, position.Row] = MovedPlayer.Number;
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
