namespace TetrisTests;

internal class GameStatisticsTests
{
    private static readonly int sleepTime = 100;
    private GameStatistics _gameStatistics;

    [SetUp]
    public void SetUp() => _gameStatistics = new GameStatistics(sleepTime);

    [Test]
    public void LevelUp_ShouldMakeDecreaseSleepTime()
    {
        var sleepTime = _gameStatistics.SleepTime;

        _gameStatistics.Level++;

        Assert.That(_gameStatistics.SleepTime, Is.LessThan(sleepTime));
    }
}
