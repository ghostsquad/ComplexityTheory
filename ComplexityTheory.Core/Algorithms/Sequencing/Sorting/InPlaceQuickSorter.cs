namespace ComplexityTheory.Core.Algorithms.Sequencing.Sorting
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     For the Brown/Black Hat Reference:
    ///     http://www.youtube.com/watch?v=ywWBy6J5gz8
    /// </summary>
    public static class InPlaceQuickSorter
    {
        #region Public Methods and Operators

        public static void InPlaceQuickSort<T>(this IList<T> collection)
        {
            InPlaceQuickSort(collection, Comparer<T>.Default);
        }

        public static void InPlaceQuickSort<T>(this IList<T> collection, IComparer<T> comparer)
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

            InPlaceQuickSortInternal(collection, comparer, 0, collection.Count - 1);
        }

        #endregion

        #region Methods

        private static void InPlaceQuickSortInternal<T>(
            IList<T> collection,
            IComparer<T> comparer,
            int indexStart,
            int indexEnd)
        {
            int blackHatIndex = indexStart;
            int brownHatIndex = indexEnd;

            while (brownHatIndex != blackHatIndex)
            {
                T brownHat = collection[brownHatIndex];
                T blackHat = collection[blackHatIndex];

                int comparisonResult = comparer.Compare(brownHat, blackHat);

                if (comparisonResult == 0)
                {
                    brownHatIndex += brownHatIndex < blackHatIndex ? 1 : -1;
                }
                else if (comparisonResult > 0)
                {
                    if (brownHatIndex < blackHatIndex)
                    {
                        collection.Swap(ref brownHatIndex, ref blackHatIndex);
                    }

                    brownHatIndex--;
                }
                else if (comparisonResult < 0)
                {
                    if (brownHatIndex > blackHatIndex)
                    {
                        collection.Swap(ref brownHatIndex, ref blackHatIndex);
                    }

                    brownHatIndex++;
                }
                else
                {
                    break;
                }
            }

            int leftEnd = blackHatIndex - 1;
            int rightStart = blackHatIndex + 1;

            if (blackHatIndex > 0 && leftEnd >= indexStart)
            {
                InPlaceQuickSortInternal(collection, comparer, indexStart, leftEnd);
            }

            if (blackHatIndex < collection.Count - 1 && rightStart <= indexEnd)
            {
                InPlaceQuickSortInternal(collection, comparer, rightStart, indexEnd);
            }
        }

        #endregion
    }
}