namespace ComplexityTheory.Core.Algorithms.Sequencing.Sorting
{
    using System.Collections.Generic;

    public static class Common
    {
        #region Public Methods and Operators

        public static void Swap<T>(this IList<T> collection, ref int position1, ref int position2)
        {
            var temp = collection[position1];
            collection[position1] = collection[position2];
            collection[position2] = temp;

            var tempPosition1 = position1;
            position1 = position2;
            position2 = tempPosition1;
        }

        public static void Swap<T>(this IList<T> collection, int position1, int position2)
        {
            collection.Swap(ref position1, ref position2);
        }

        #endregion
    }
}