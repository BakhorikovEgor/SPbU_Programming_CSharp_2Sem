namespace RoutersTest;

public class Tests
{
    [TestCase
        (
        """
        1: 3 (4), 2 (11), 5 (6), 6 (5), 5 (3)
        2: 7 (12), 9 (10), 4 (3)
        3: 7 (7)
        4: 3 (8)
        5: 2 (12)
        6: 9 (13), 4 (5)
        7: 8 (59), 6 (3), 3 (5)
        8: 9 (5)
        """
        , new string[]

        {
         "1: 2 (11)",
         "2: 7 (12)",
         "7: 8 (59)",
         "5: 2 (12)",
         "2: 9 (10)",
         "6: 9 (13)",
         "3: 7 (7)",
         "4: 3 (8)"

        })]
    [TestCase("""
        1: 2 (10), 3 (5)
        2: 3 (1)
        """
        , new string[]
        {"1: 2 (10)",
         "1: 3 (5)"
        })]
    public void CorrectInput_ShouldReturnOptimalTopology(string topology, string[] expectedConfiguration)
    {
        var actualConfiguration = ConfigurationBuilder.BuildConfiguration(topology);

        foreach (var element in expectedConfiguration)
        {
            Assert.That(actualConfiguration.Contains(element), Is.True);
        }
    }

    [TestCase(
        """
        1: 2 (3), 3 (12)
        2: 3 (11)
        3: 4 (10)
        5: 6 (18)
        """)]
    [TestCase(
        """
        1: 1 (5)
        3: 4 (10)
        """)]
    public void DisconnectedTopology_ShouldThrowException(string topology)
        => Assert.Throws<TopologyNotConnectedException>(() => ConfigurationBuilder.BuildConfiguration(topology));

    [TestCase(
        """
        1:
        2:
        """)]
    [TestCase(
        """
        1: 2(10)
        """)]
    public void WrongTopologyFormat_ShouldThrowException(string topology)
        => Assert.Throws<FormatException>(() => ConfigurationBuilder.BuildConfiguration(topology));

    [Test]
    public void NegativeThroughput_ShouldThrowException()
        => Assert.Throws<ArgumentException>(() => ConfigurationBuilder.BuildConfiguration("1: 2 (-10)"));

    [Test]
    public void EmptyTopology_ShouldThrowException()
        => Assert.Throws<ArgumentException>(() => ConfigurationBuilder.BuildConfiguration(string.Empty));
}
