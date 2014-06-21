namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem
{
    public class Supply
    {
        #region Constructors and Destructors

        public Supply(int weight, int value)
        {
            this.Weight = weight;
            this.Value = value;
        }

        #endregion

        #region Public Properties

        public int Value { get; private set; }

        public int Weight { get; private set; }

        #endregion
    }
}