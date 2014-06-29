namespace ComplexityTheory.Test.Algorithms.GraphTheory
{
    using ComplexityTheory.Core.Algorithms.GraphTheory.ShortestPath;

    using FluentAssertions;

    using Xunit;

    public class DijkstraTests
    {
        [Fact]
        public void GivenSingleVertexGraph_ExpectDistance0()
        {
            var startEnd = new GraphVertex("A");
            var solution = Dijkstra.Solve(startEnd, startEnd);

            solution.Should().Be(0);
        }

        [Fact]
        public void GivenTriangleGraph_ExpectDistance1()
        {
            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");
            var vertexC = new GraphVertex("C");

            // A -> B -> C
            vertexA.AddConnectionToVertex(vertexB);
            vertexB.AddConnectionToVertex(vertexC);

            // A -> C
            vertexA.AddConnectionToVertex(vertexC);

            var solution = Dijkstra.Solve(vertexA, vertexC);

            solution.Should().Be(1);
        }

        [Fact]
        public void GivenDeadEnd_ExpectDistance2()
        {
            // A -> B
            // |
            // v
            // C -> D

            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");
            var vertexC = new GraphVertex("C");
            var vertexD = new GraphVertex("D");

            vertexA.AddConnectionToVertex(vertexB);
            vertexA.AddConnectionToVertex(vertexC);

            vertexC.AddConnectionToVertex(vertexD);

            var solution = Dijkstra.Solve(vertexA, vertexD);

            solution.Should().Be(2);
        }

        [Fact]
        public void GivenMultipleEqualDistancePaths_ExpectOutput3()
        {
            // A -> B -> C
            // A -> D -> C

            // C -> E

            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");
            var vertexC = new GraphVertex("C");
            var vertexD = new GraphVertex("D");
            var vertexE = new GraphVertex("E");

            vertexA.AddConnectionToVertex(vertexB);
            vertexB.AddConnectionToVertex(vertexC);

            vertexA.AddConnectionToVertex(vertexD);
            vertexD.AddConnectionToVertex(vertexC);

            vertexD.AddConnectionToVertex(vertexC);

            vertexC.AddConnectionToVertex(vertexE);

            var solution = Dijkstra.Solve(vertexA, vertexE);

            solution.Should().Be(3);
        }

        [Fact]
        public void GivenEndlessLoop_ExpectReturnNegativeOne()
        {
            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");
            var vertexC = new GraphVertex("C");
            var vertexD = new GraphVertex("D");

            vertexA.AddConnectionToVertex(vertexB);
            vertexB.AddConnectionToVertex(vertexC);
            vertexC.AddConnectionToVertex(vertexA);

            var solution = Dijkstra.Solve(vertexA, vertexD);

            solution.Should().Be(-1);
        }

        [Fact]
        public void GivenTwoWayGraph_ExpectNoBackTracking()
        {
            // A <-> B
            // ^
            // |
            // v
            // C <-> D <-> E
            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");
            var vertexC = new GraphVertex("C");
            var vertexD = new GraphVertex("D");
            var vertexE = new GraphVertex("E");

            vertexA.AddConnectionToVertex(vertexB);
            vertexB.AddConnectionToVertex(vertexA);

            vertexA.AddConnectionToVertex(vertexC);
            vertexC.AddConnectionToVertex(vertexA);

            vertexC.AddConnectionToVertex(vertexD);

            vertexD.AddConnectionToVertex(vertexE);
            vertexE.AddConnectionToVertex(vertexD);

            var solution = Dijkstra.Solve(vertexA, vertexE);

            solution.Should().Be(3);
        }

        [Fact]
        public void GivenDestinationNotConnectedToStartPoint_ExpectNegativeOneResult()
        {
            var vertexA = new GraphVertex("A");
            var vertexB = new GraphVertex("B");

            var vertexC = new GraphVertex("C");

            vertexA.AddConnectionToVertex(vertexB);

            var solution = Dijkstra.Solve(vertexA, vertexC);

            solution.Should().Be(-1);
        }
    }
}
