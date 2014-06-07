namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public static class InPlaceCocktailBubbleSorter
    {
        #region Public Methods and Operators

        public static void InPlaceCocktailBubbleSort<T>(this IList<T> collection)
        {
            InPlaceCocktailBubbleSort(collection, Comparer<T>.Default);
        }

        public static void InPlaceCocktailBubbleSort<T>(this IList<T> collection, IComparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            if (collection.Count < 2)
            {
                return;
            }

            bool swapped;
            var startIndex = -1;
            var endIndex = collection.Count - 2;

            do
            {
                startIndex++;
                swapped = collection.BubbleSort(comparer, startIndex, endIndex);

                if (!swapped)
                {
                    break;
                }

                endIndex--;
                if (endIndex <= startIndex)
                {
                    break;
                }

                swapped = collection.BubbleSort(comparer, startIndex, endIndex, true);
            }
            while (swapped);
        }

        #endregion

        #region Methods

        private static bool BubbleSort<T>(
            this IList<T> collection,
            IComparer<T> comparer,
            int startIndex,
            int endIndex,
            bool inReverse = false)
        {
            var swapped = false;

            if (!inReverse)
            {
                for (var i = startIndex; i <= endIndex; i++)
                {
                    if (collection.OrderAppropriately(comparer, i))
                    {
                        swapped = true;
                    }
                }
            }
            else
            {
                for (var i = endIndex; i >= startIndex; i--)
                {
                    if (collection.OrderAppropriately(comparer, i))
                    {
                        swapped = true;
                    }
                }
            }

            return swapped;
        }

        private static bool OrderAppropriately<T>(this IList<T> collection, IComparer<T> comparer, int index)
        {
            var x = collection[index];
            var y = collection[index + 1];
            if (comparer.Compare(x, y) > 0)
            {
                collection.Swap(index, index + 1);
                return true;
            }

            return false;
        }

        #endregion
    }
}