namespace KnapsackProblem
{
    using System.Collections.Generic;

    public abstract class KnapsackAlgorithmBase : IKnapsackAlgorithm
    {
        public Knapsack Knapsack { get; protected set; }

        public abstract Knapsack Execute(List<Supply> possibleSupplies, int maxWeight);
    }
}