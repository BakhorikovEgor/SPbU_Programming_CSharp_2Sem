using System.Text;

namespace Routers;

internal static class ConfigurationBuilder
{
    private class GraphEdge
    {
        public int Weight { get; }
        public int FirstVertex { get; }
        public int SecondVertex { get; }

        public GraphEdge(int weight, int firstVertex, int secondVertex)
        {
            Weight = weight;
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }
    }

    public static string BuildConfiguration(string topology)
    {
        (var edges, var vertexCount) = Parse(topology);

        var configuration = new List<GraphEdge>();
        var connectedVertexes = new HashSet<int> { 1 };
        while (connectedVertexes.Count < vertexCount)
        {
            GraphEdge maxCurrentEdge = FindMaxCurrentEdge(edges, connectedVertexes);
            if (maxCurrentEdge.Weight == int.MinValue) 
            { 
                break; 
            }

            configuration.Add(maxCurrentEdge);
            connectedVertexes.Add(maxCurrentEdge.FirstVertex);
            connectedVertexes.Add(maxCurrentEdge.SecondVertex);
        }

        if (connectedVertexes.Count != vertexCount)
        {
            throw new TopologyNotConnectedException("");
        }
        return CreateConfigurationString(configuration);          
    }

    private static (GraphEdge[],int) Parse(string topology)
    {
        var vertexes = new HashSet<int>();
        var result = new List<GraphEdge>();

        foreach (var component in topology.Split("\n"))
        {
            var data = component.Split(":");
            var firstVertex = int.Parse(data[0]);
            foreach (var edgeInfo in data[1].Split(',')) 
            {
                var temp = edgeInfo.Replace("(","").Replace(")","").Split(" ");
                var secondVertex = int.Parse(temp[1]);
                var edgeWeight = int.Parse(temp[2]);

                result.Add(new GraphEdge(edgeWeight, firstVertex, secondVertex));
                vertexes.Add(secondVertex);
            }
            vertexes.Add(firstVertex);
        }

        return (result.ToArray(), vertexes.Count);
    }


    private static GraphEdge FindMaxCurrentEdge(GraphEdge[] edges, HashSet<int> connectedVertexes)
    {
        var result = new GraphEdge(int.MinValue, 0, 0);
        foreach (var edge in edges)
        {
            if ((connectedVertexes.Contains(edge.FirstVertex) || connectedVertexes.Contains(edge.SecondVertex))
                && (!(connectedVertexes.Contains(edge.FirstVertex) && connectedVertexes.Contains(edge.SecondVertex))))
            {
                if (result.Weight < edge.Weight)
                {
                    result = edge;
                }
            }
        }
        return result;
    }

    private static string CreateConfigurationString(List<GraphEdge> edges) 
    {
        var builder = new StringBuilder();
        foreach(var edge in edges)
        {
            var edgeRepresentation = $"{edge.FirstVertex}: {edge.SecondVertex} ({edge.Weight})";
            builder.Append(edgeRepresentation + '\n');
        }
        return builder.ToString();
    }
}
