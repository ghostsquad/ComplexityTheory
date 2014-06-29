namespace ComplexityTheory.Core.Algorithms.GraphTheory.ShortestPath
{
    using System.Collections.Generic;

    public class GraphVertex
    {
        public string Name { get; private set; }

        public GraphVertex(string name)
        {
            this.Name = name;
            this.Connections = new List<GraphEdge>();
        }

        public List<GraphEdge> Connections { get; set; }

        public void AddConnectionToVertex(GraphVertex destinationVertex)
        {
            var edge = new GraphEdge { PointA = this, PointB = destinationVertex };
            this.Connections.Add(edge);
        }
    }
}