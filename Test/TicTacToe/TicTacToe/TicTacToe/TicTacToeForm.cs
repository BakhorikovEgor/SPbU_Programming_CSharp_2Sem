using TicTacToeGame;

namespace TicTacToeForm;

public partial class TicTacToeForm : Form
{
    private Game game = new Game();
    public TicTacToeForm()
    {
        InitializeComponent();
    }

    private void OnGameFieldButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        if (game.IsGameOver)
        {
            ClearGameField();
            game = new Game();
        }

        if (!button.Text.Equals(string.Empty)) return;

        var index = button.TabIndex;

        var row = (uint)index / 3;
        var column = (uint)index % 3;

        game.Move((row, column));

        button.Text = game.MovedPlayer.Sign;

        if (game.IsGameOver)
        {
            GameInfoTextBox.Text = game.Draw ? "Draw !" : $"Player {game.MovedPlayer.Number} won !";
        }
        else
        {
            GameInfoTextBox.Text = $"Player " +
                                            $"{(game.MovedPlayer == Player.First
                                            ? Player.Second.Number
                                            : Player.First.Number)} turns";
        }

    }

    private void ClearGameField()
    {
        FirstGameFieldButton.Text = string.Empty;
        SecondGameFieldButton.Text = string.Empty;
        ThirdGameFieldButton.Text = string.Empty;
        FourthGameFieldButton.Text = string.Empty;
        FifthGameFieldButton.Text = string.Empty;
        SixthGameFieldButton.Text = string.Empty;
        SeventhGameFieldButton.Text = string.Empty;
        EighthGameFieldButton.Text = string.Empty;
        NinthGameFieldButton.Text = string.Empty;
    }


}