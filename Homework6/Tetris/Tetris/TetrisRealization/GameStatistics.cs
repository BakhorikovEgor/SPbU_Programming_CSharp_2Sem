namespace Tetris.Realization;

/// <summary>
/// Statistics of the current Tetris game.
/// </summary>
public class GameStatistics
{
    public static readonly int StandardBonus = 10;
    public static readonly int LineBonus = 100;

    private static readonly int _sleepCoefficient = 25;

    private int _level = 0;
    private int _score = 0;
    private int _newLevelScore = 100;

    /// <summary>
    /// How many lines were cleaned in current game.
    /// </summary>
    public int Cleans { get; set; } = 0;

    /// <summary>
    /// How long game should pause after action.
    /// </summary>
    public int SleepTime { get; private set; } = 170;

    /// <summary>
    /// Level of current game. 
    /// SleepTime depends on it.
    /// </summary>
    public int Level
    {
        get => _level;
        set
        {
            SleepTime += _sleepCoefficient * (_level - value);
            _level = value;
        }
    }

    /// <summary>
    /// Score of current game.
    /// Level depends on it.
    /// </summary>
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (_score >= _newLevelScore)
            {
                _newLevelScore <<= 1;
                Level++;
            }
        }
    }
}
