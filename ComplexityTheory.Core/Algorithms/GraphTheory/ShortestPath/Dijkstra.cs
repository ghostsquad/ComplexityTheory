namespace ComplexityTheory.Core.Algorithms.GraphTheory.ShortestPath
{
    using System.Collections.Generic;
    using System.IO;

    public static class Dijkstra
    {        
        public static int Solve(GraphVertex startVertex, GraphVertex destinationVertex)
        {            
            var distanceToDestination = -1;
            var knownVertexes = new Dictionary<GraphVertex, int>();
            var unvisitedVertexes = new BetterQueue<GraphVertex>();
            var visitedVertexes = new HashSet<GraphVertex>();

            var currentVertex = startVertex;
            knownVertexes.Add(currentVertex, 0);

            while (true)
            {
                if (currentVertex == destinationVertex)
                {
                    distanceToDestination = knownVertexes[currentVertex];
                    break;
                }

                var currentShortestPathDistance = -1;
                GraphVertex currentShortestPathVertex = null;

                foreach (var connection in currentVertex.Connections)
                {
                    var newVertex = connection.PointA == currentVertex ? connection.PointB : connection.PointA;

                    if (visitedVertexes.Contains(newVertex))
                    {
                        continue;
                    }

                    if (!unvisitedVertexes.Contains(newVertex))
                    {
                        unvisitedVertexes.Enqueue(newVertex);
                    }

                    var pathDistance = knownVertexes[currentVertex] + 1;
                    if (knownVertexes.ContainsKey(newVertex))
                    {
                        if (knownVertexes[newVertex] > pathDistance)
                        {
                            knownVertexes[newVertex] = pathDistance;
                        }
                    }
                    else
                    {
                        knownVertexes.Add(newVertex, pathDistance);
                    }

                    if (currentShortestPathDistance == -1 || currentShortestPathDistance > pathDistance)
                    {
                        currentShortestPathDistance = pathDistance;
                        currentShortestPathVertex = newVertex;
                    }
                }

                visitedVertexes.Add(currentVertex);

                // if this is a dead-end
                if (currentShortestPathDistance == -1)
                {
                    if (unvisitedVertexes.Count > 0)
                    {
                        currentVertex = unvisitedVertexes.Dequeue();
                    }
                    else
                    {
                        // the destination is not in the graph
                        break;
                    }
                }
                else
                {
                    currentVertex = currentShortestPathVertex;
                }
            }

            return distanceToDestination;
        }
    }
}
