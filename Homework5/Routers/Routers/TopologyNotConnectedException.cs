namespace Routers;

public class TopologyNotConnectedException : Exception
{
    public TopologyNotConnectedException() : base() { }
    public TopologyNotConnectedException(string message) : base(message) { }
}
