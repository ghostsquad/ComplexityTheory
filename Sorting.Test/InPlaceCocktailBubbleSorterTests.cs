namespace Sorting.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InPlaceCocktailBubbleSorterTests
    {
        #region Static Fields

        private static readonly Type SorterType = typeof(InPlaceCocktailBubbleSorter);

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void GivenEndPointsReversedList()
        {
            Common.GivenEndPointsReversedList(SorterType);
        }

        [TestMethod]
        public void GivenReversedList()
        {
            Common.GivenReversedList(SorterType);
        }

        [TestMethod]
        public void GivenSinglePopulationListExpectNoChange()
        {
            Common.GivenSinglePopulationListExpectNoChange(SorterType);
        }

        [TestMethod]
        public void GivenSortedList()
        {
            Common.GivenSortedList(SorterType);
        }

        [TestMethod]
        public void GivenUnSortedList()
        {
            Common.GivenUnSortedList(SorterType);
        }

        [TestMethod]
        public void GivenUnSortedListWithDuplicates()
        {
            Common.GivenUnSortedListWithDuplicates(SorterType);
        }

        #endregion
    }
}