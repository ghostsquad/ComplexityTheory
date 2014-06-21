namespace ComplexityTheory.Core.Algorithms.Sequencing
{
    public static class MissingElementFinder
    {
        public static int GetMissingElement(int?[] array1, int?[] array2)
        {
            var missingElement = 0;

            for (var i = array1.GetLowerBound(0); i <= array1.GetUpperBound(0); i++)
            {
                var x = array1[i] ?? 0;
                var y = array2[i] ?? 0;

                missingElement ^= x ^ y;
            }

            return missingElement;
        }
    }
}