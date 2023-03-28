namespace Routers;

internal static class RouterNetBuilder
{
    public static void CreateConfiguration(string netTopology)
    {
        var routersInfo = netTopology.Split("\n");

        var routers = new Dictionary<int, Router>();
        for (int i = 0; i < routersInfo.Length; ++i)
        {
            (var routerNumber, var linkedRouters, var throughputs) = Parse(routersInfo[i]);
            if (!routers.ContainsKey(routerNumber))
            {
                routers[routerNumber] = new Router(routerNumber);
            }

            for (int j = 0; j < linkedRouters.Length; ++j)
            {
                if (!routers.ContainsKey(linkedRouters[j]))
                {
                    routers[linkedRouters[j]] = new Router(linkedRouters[j]);
                }
                routers[routerNumber].AddLinkedRouter(routers[linkedRouters[j]], throughputs[j]);
            }
        }

        if (routersInfo.Length == 0)
        {
            return;
        }

        var visited = new bool[routers.Count + 1];
        if (DFS(routers[1], new bool[routers.Count + 1]) == routers.Count)
        {
            Console.WriteLine("net is good");
        }
        else
        {
            Console.WriteLine("No net");
        }

        
    }

    private static int DFS(Router router, bool[] visited)
    {
        var visitedRouters = 1;
        visited[router.Number] = true;

        foreach (var linkedRouter in router.LinkedRouters.Keys)
        {
            if (!visited[linkedRouter.Number])
            {
                visitedRouters += DFS(linkedRouter, visited);
            }
        }

        return visitedRouters;
    }

    private static (int, int[], int[]) Parse(string routerInfo)
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
