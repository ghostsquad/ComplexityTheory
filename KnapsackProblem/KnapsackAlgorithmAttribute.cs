namespace KnapsackProblem
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class KnapsackAlgorithmAttribute : Attribute
    {
        private readonly KnapsackAlgorithmType algorithmType;

        public KnapsackAlgorithmAttribute(KnapsackAlgorithmType algorithmType)
        {
            this.algorithmType = algorithmType;
        }

        public KnapsackAlgorithmType TypeOfAlgorithm
        {
            get { return this.algorithmType; }
        }
    }
}