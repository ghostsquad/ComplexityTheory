namespace ComplexityTheory.Test.Algorithms.Combinatorics.KnapsackProblem
{
    using System.Collections.Generic;

    using ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem;

    using FluentAssertions;

    using Xunit;

    public class GreedyApproximationTests
    {
        private readonly KnapsackSolver knapsackSolver = new KnapsackSolver();

        /// <summary>
        /// http://en.wikipedia.org/wiki/Knapsack_problem
        /// </summary>
        [Fact]
        public void GreedyApproximationUsingWikipediaAnswer()
        {
            // arrange
            const int MaxWeight = 15;
            var possibleSupplies = new List<Supply>()
                                       {
                                           new Supply(12, 4),
                                           new Supply(2, 2),
                                           new Supply(1, 2),
                                           new Supply(4, 10),
                                           new Supply(1, 1)
                                       };
            const int ExpectedContentValue = 36;
            const int ExpectedWeight = MaxWeight;
            var expectedSupplies = new List<Supply>
                                       {
                                           new Supply(4, 10),
                                           new Supply(4, 10),
                                           new Supply(4, 10),
                                           new Supply(1, 2),
                                           new Supply(1, 2),
                                           new Supply(1, 2)
                                       };

            // act
            var knapsack = this.knapsackSolver.SolveProblemUsing(
                KnapsackAlgorithmType.GreedyApproximation,
                possibleSupplies,
                MaxWeight);

            // assert
            knapsack.ContentValue.Should().Be(ExpectedContentValue);
            knapsack.CurrentWeight.Should().Be(ExpectedWeight);
        }
    }
}