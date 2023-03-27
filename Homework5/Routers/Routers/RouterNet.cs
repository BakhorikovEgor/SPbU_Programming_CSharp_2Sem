namespace Routers;

internal static class RouterNetBuilder
{
    private class Router
    {
        private Dictionary<Router, int> linkedRouters = new Dictionary<Router, int>();
        public int linkedRoutersNumber { get; private set; } = 0;
        internal void AddRouter(Router linkedRouter, int throughput)
        {
            if (linkedRouters.ContainsKey(linkedRouter))
            {
                linkedRouters[linkedRouter] = Math.Max(linkedRouters[linkedRouter], throughput);
            }
            else
            {
                linkedRouters[linkedRouter] = throughput;
                linkedRoutersNumber++;
            }
        }

    }

    public static void CreateConfiguration(string netTopology)
    {
        var routersInfo = netTopology.Split("\n");

        var routers = new List<Router>();
        for (int i = 0; i < routersInfo.Length; ++i)
        {
            (var routerNumber, var linkedRouters, var throughputs) = ParseNetTopology(routersInfo[i]);
            routers[routerNumber] = new Router();

            for (int j = 0; j < linkedRouters.Length; ++j)
            {
                routers[routerNumber].AddRouter(routers[linkedRouters[j]], throughputs[j]);
            }
        }
    }

    private static (int, int[], int[]) ParseNetTopology(string routerInfo)
    {
        var data = routerInfo.Split(':');

        var routerNumber = int.Parse(data[0]);
        var linkedRoutersInfo = data[1].Split(",");
        var linkedRouters = new int[linkedRoutersInfo.Length];
        var throughputs = new int[linkedRoutersInfo.Length];

        for (int i = 0; i < linkedRoutersInfo.Length; ++i)
        {
            var linkedRouterInfo = linkedRoutersInfo[i].Replace("(", "").Replace(")","").Split(" ");
            linkedRouters[i] = int.Parse(linkedRouterInfo[1]);
            throughputs[i] = int.Parse(linkedRouterInfo[2]);
        }

        return (routerNumber, linkedRouters, throughputs);
    }

}
