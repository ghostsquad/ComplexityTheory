namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem
{
    using System.Collections.Generic;

    public interface IKnapsackAlgorithm
    {
        Knapsack Execute(List<Supply> possibleSupplies, int maxWeight);
    }
}