namespace Routers;

internal class GraphEdge
{
    public static readonly GraphEdge MinGraphEdge = new GraphEdge(-1, -1, -1);
    public int Weight { get; }
    public int FirstVertex { get; }
    public int SecondVertex { get; }
    
    public GraphEdge( int weight, int firstVertex, int secondVertex)
    {
        Weight = weight;
        FirstVertex = firstVertex;
        SecondVertex = secondVertex;
    }
}
