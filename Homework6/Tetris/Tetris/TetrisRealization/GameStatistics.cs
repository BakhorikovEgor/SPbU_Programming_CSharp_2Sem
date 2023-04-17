namespace Tetris.Realization;

public class GameStatistics
{
    public static readonly int StandardBonus = 10;
    public static readonly int LineBonus = 100;

    private int _level = 0;
    private int _score = 0;
    private int _newLevelScore = 100;

    public int Cleans { get; set; } = 0;

    public int SleepTime { get; set; }

    public int Level
    {
        get => _level;
        set
        {
            SleepTime += 25 * (_level - value);
            _level = value;
        }
    }

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

    public GameStatistics(int sleepTime) => SleepTime = sleepTime;
}
