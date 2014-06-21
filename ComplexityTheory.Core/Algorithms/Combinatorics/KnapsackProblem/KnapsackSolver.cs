namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem.Algorithms;

    public class KnapsackSolver
    {
        #region Static Fields

        private static readonly ArrayList RegisteredImplementations;

        #endregion

        #region Constructors and Destructors

        static KnapsackSolver()
        {
            RegisteredImplementations = new ArrayList();
            RegisterClass(typeof(GreedyApproximation));
        }

        #endregion

        #region Public Methods and Operators

        public Knapsack SolveProblemUsing(
            KnapsackAlgorithmType algorithmType,
            List<Supply> possibleSupplies,
            int maxWeight)
        {
            // loop thru all registered implementations
            foreach (Type impl in RegisteredImplementations)
            {
                // get attributes for this type
                object[] attrlist = impl.GetCustomAttributes(true);

                // loop thru all attributes for this class
                foreach (object attr in attrlist)
                {
                    if (attr is KnapsackAlgorithmAttribute)
                    {
                        if (((KnapsackAlgorithmAttribute)attr).TypeOfAlgorithm.Equals(algorithmType))
                        {
                            IKnapsackAlgorithm knapsackAlgorithm = (KnapsackAlgorithmBase)Activator.CreateInstance(impl);

                            return knapsackAlgorithm.Execute(possibleSupplies, maxWeight);
                        }
                    }
                }
            }

            throw new Exception("Could not find a KnapsackAlgorithmBase implementation for this AlgorithmType");
        }

        #endregion

        #region Methods

        private static void RegisterClass(Type requestStrategyImpl)
        {
            if (!requestStrategyImpl.IsSubclassOf(typeof(KnapsackAlgorithmBase)))
            {
                throw new Exception("ArithmiticStrategy must inherit from class KnapsackAlgorithmBase");
            }

            RegisteredImplementations.Add(requestStrategyImpl);
        }

        #endregion
    }
}