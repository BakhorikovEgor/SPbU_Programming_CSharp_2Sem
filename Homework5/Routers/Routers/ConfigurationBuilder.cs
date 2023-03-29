using System.Diagnostics.Metrics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Routers;

/// <summary>
/// Using the Prim`s algorithm, based on the given network topology, 
/// build the optimal configuration of routers, which is the maximum spanning tree.
/// </summary>
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

    /// <summary>
    /// Realization of Prim`s algorithm for building optimal routers configuration.
    /// </summary>
    /// <param name="topology"> 
    /// Initial information about the connections of routers in the format: 
    /// router: connected router (throughput), etc...
    /// </param>
    /// <returns> 
    /// Text from strings in the format: 
    /// router: connected router(throughput).
    /// </returns>
    /// <exception cref="TopologyNotConnectedException"> Graph is not connected.</exception>
    /// <exception cref="FormatException"> Input has wrong format. </exception>
    public static string BuildConfiguration(string topology)
    {
        if (topology == string.Empty)
        {
            throw new ArgumentException("Toplogy can not be empty !");
        }
        
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
            throw new TopologyNotConnectedException("\r\nNot every router is reachable..");
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
