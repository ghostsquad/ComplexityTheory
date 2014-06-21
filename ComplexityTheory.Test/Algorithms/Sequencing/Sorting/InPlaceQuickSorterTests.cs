namespace ComplexityTheory.Test.Algorithms.Sequencing.Sorting
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ComplexityTheory.Core.Algorithms.Sequencing.Sorting;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class InPlaceQuickSorterTests
    {
        #region Static Fields

        private static readonly Type SorterType = typeof(InPlaceQuickSorter);

        #endregion

        #region Public Methods and Operators

        [Fact]
        public void GivenEndPointsReversedList()
        {
            Common.GivenEndPointsReversedList(SorterType);
        }

        [Fact]
        public void GivenReversedList()
        {
            Common.GivenReversedList(SorterType);
        }

        [Fact]
        public void GivenSinglePopulationListExpectNoChange()
        {
            Common.GivenSinglePopulationListExpectNoChange(SorterType);
        }

        [Fact]
        public void GivenSortedList()
        {
            Common.GivenSortedList(SorterType);
        }

        [Fact]
        public void GivenUnSortedList()
        {
            Common.GivenUnSortedList(SorterType);
        }

        [Fact]
        public void GivenUnSortedListWithDuplicates()
        {
            Common.GivenUnSortedListWithDuplicates(SorterType);
        }

        #endregion
    }
}