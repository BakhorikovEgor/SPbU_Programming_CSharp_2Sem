namespace Routers;

internal class TopologyNotConnectedException: Exception
{
    public TopologyNotConnectedException() : base() { }
    public TopologyNotConnectedException(string message) : base(message) { }
}
