namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem
{
    using System.Collections.Generic;

    public class Knapsack
    {
        #region Constructors and Destructors

        public Knapsack()
        {
            this.Contents = new List<Supply>();
        }

        #endregion

        #region Public Properties

        public int ContentValue { get; set; }

        public List<Supply> Contents { get; private set; }

        public int CurrentWeight { get; set; }

        public int MaxWeight { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddSupply(Supply supply)
        {
            this.Contents.Add(supply);
            this.CurrentWeight += supply.Weight;
            this.ContentValue += supply.Value;
        }

        #endregion
    }
}