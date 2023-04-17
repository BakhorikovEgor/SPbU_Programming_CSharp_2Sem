namespace TetrisTests;

internal class GameTests
{
    private static readonly int GameLength = 3;
    private static readonly int GameWidth = 8;

    private Game _game;
    private ConsoleColor[,] _field;

    [SetUp]
    public void SetUp()
    {
        _game = new Game(GameLength, GameWidth);

        _field = new ConsoleColor[_game.Length, _game.Width];
        Array.Copy(_game.Field, _field, _game.Length * _game.Width);
    }

    [Test]
    public void ChangePauseStateWhenGameIsOver_ShouldNotChangeState()
    {
        while (!_game.IsGameOver)
        {
            _game.MoveDown(null, EventArgs.Empty);
        }

        var expected = _game.IsGamePaused;
        _game.ChangeGamePauseState(null, EventArgs.Empty);

        var actual = _game.IsGamePaused;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ChangePauseStateWhenGameIsNotOver_ShouldChangeState()
    {
        var expected = _game.IsGamePaused;

        _game.ChangeGamePauseState(null, EventArgs.Empty);

        var actual = _game.IsGamePaused;

        Assert.That(actual, Is.Not.EqualTo(expected));
    }

    [Test]
    public void Reset_ShouldChangeScoreToZero()
    {
        _game.Reset(null, EventArgs.Empty);

        Assert.That(_game.Statistics.Score == 0, Is.True);
    }


    [Test]
    public void MovePausedGame_ShouldNotChangeGameField()
    {
        _game.ChangeGamePauseState(null, EventArgs.Empty);

        _game.MoveDown(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.MoveLeft(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.MoveRight(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.Rotate(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);
    }

    [Test]
    public void MoveEndedGame_ShouldNotChangeGameField()
    {
        while (!_game.IsGameOver)
        {
            _game.MoveDown(null, EventArgs.Empty);
        }
        Array.Copy(_game.Field, _field, _field.GetLength(0) * _field.GetLength(1));

        _game.MoveDown(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.MoveLeft(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.MoveRight(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);

        _game.Rotate(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);
    }

    [Test]
    public void MoveDown_ShouldAlwaysChangeGameField()
    {
        _game.MoveDown(null, EventArgs.Empty);
        Assert.That(AreFieldsEqual(_field, _game.Field), Is.False);
    }

    [Test]
    public void MoveLeftAndRight_ShouldNotChangeField()
    {
        _game.MoveLeft(null, EventArgs.Empty);
        _game.MoveRight(null, EventArgs.Empty);

        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);
    }

    [Test]
    public void MoveRotateFourTimes_ShouldNotChangeField()
    {
        _game.Rotate(null, EventArgs.Empty);
        _game.Rotate(null, EventArgs.Empty);
        _game.Rotate(null, EventArgs.Empty);
        _game.Rotate(null, EventArgs.Empty);

        Assert.That(AreFieldsEqual(_field, _game.Field), Is.True);
    }


    private bool AreFieldsEqual(ConsoleColor[,] firstField, ConsoleColor[,] secondField)
    {
        if (firstField.GetLength(0) != secondField.GetLength(0) ||
            firstField.GetLength(1) != secondField.GetLength(1))
        {
            return false;
        }

        for (var row = 0; row < firstField.GetLength(0); ++row)
        {
            for (var column = 0; column < firstField.GetLength(1); ++column)
            {
                if (firstField[row, column] != secondField[row, column])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
