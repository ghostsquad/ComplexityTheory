namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem.Algorithms
{
    using System.Collections.Generic;

    [KnapsackAlgorithm(KnapsackAlgorithmType.GreedyApproximation)]
    public class GreedyApproximation : KnapsackAlgorithmBase
    {
        #region Fields

        private List<KeyValuePair<float, Supply>> suppliesByValueWeightRatio;

        #endregion

        #region Public Methods and Operators

        public override Knapsack Execute(List<Supply> possibleSupplies, int maxWeight)
        {
            this.Knapsack = new Knapsack { MaxWeight = maxWeight };
            this.suppliesByValueWeightRatio = new List<KeyValuePair<float, Supply>>();

            foreach (var supply in possibleSupplies)
            {
                float valueWeightRatio = (float)supply.Value / (float)supply.Weight;
                this.suppliesByValueWeightRatio.Add(new KeyValuePair<float, Supply>(valueWeightRatio, supply));
            }

            this.suppliesByValueWeightRatio.Sort((x, y) => DescendedFloatComparer.Default.Compare(x.Key, y.Key));

            foreach (var supplyKeyValuePair in this.suppliesByValueWeightRatio)
            {
                while (true)
                {
                    if (this.Knapsack.CurrentWeight + supplyKeyValuePair.Value.Weight <= maxWeight)
                    {
                        this.Knapsack.AddSupply(supplyKeyValuePair.Value);
                    }
                    else
                    {
                        break;
                    }
                }

                if (this.Knapsack.CurrentWeight == maxWeight)
                {
                    break;
                }
            }

            return this.Knapsack;
        }

        #endregion

        private class DescendedFloatComparer : IComparer<float>
        {
            #region Public Properties

            public static DescendedFloatComparer Default
            {
                get
                {
                    return new DescendedFloatComparer();
                }
            }

            #endregion

            #region Public Methods and Operators

            public int Compare(float x, float y)
            {
                return 0 - Comparer<float>.Default.Compare(x, y);
            }

            #endregion
        }
    }
}