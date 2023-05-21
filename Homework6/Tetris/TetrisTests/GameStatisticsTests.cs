namespace TetrisTests;

internal class GameStatisticsTests
{
    private GameStatistics _gameStatistics;

    [SetUp]
    public void SetUp() => _gameStatistics = new();

    [Test]
    public void LevelUp_ShouldMakeDecreaseSleepTime()
    {
        var sleepTime = _gameStatistics.SleepTime;

        _gameStatistics.Level++;

        Assert.That(_gameStatistics.SleepTime, Is.LessThan(sleepTime));
    }
}
