namespace Routers;
internal class Router 
{
    public Dictionary<Router, int> LinkedRouters { get; private set; } = new Dictionary<Router, int>();
    public int Number { get; }

    public Router(int number) => Number = number;

    internal void AddLinkedRouter(Router linkedRouter, int throughput)
    {
        LinkedRouters[linkedRouter] = LinkedRouters.ContainsKey(linkedRouter)
                                    ? Math.Max(LinkedRouters[linkedRouter], throughput)
                                    : throughput;

        if (!linkedRouter.LinkedRouters.ContainsKey(this))
        {
            linkedRouter.AddLinkedRouter(this, throughput);
        }
    }
}