namespace TicTacToe;

public partial class Form1 : Form
{
    private Game game = new Game();
    public Form1()
    {
        InitializeComponent();
    }

    private void OnGameFieldButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        if (game.IsGameOver && !button.Text.Equals(string.Empty)) return;

        var index = button.TabIndex;

        var row = (uint) index / 3;
        var column = (uint) index % 3;

        game.Move((row, column));

        button.Text = game.movedPlayer.Sign;
        
        if (game.IsGameOver)
        {

        }
    }
}