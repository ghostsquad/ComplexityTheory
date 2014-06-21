namespace ComplexityTheory.Test.Algorithms.Sequencing
{
    using System.Diagnostics.CodeAnalysis;

    using ComplexityTheory.Core.Algorithms.Sequencing;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class MissingElementFinderTests
    {
        #region Public Methods and Operators

        [Fact]
        public void FirstArrayWithMissingValue()
        {
            const int ExpectedResult = 5;
            var array1 = new int?[] { 1, null, 3 };
            var array2 = new int?[] { 1, 5, 3 };

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void GivenConsectiveNumbers()
        {
            const int ExpectedResult = 2;
            var array1 = new int?[] { 1, 2, 3 };
            var array2 = new int?[] { 1, null, 3 };

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void GivenConsectiveNumbersMissingNumberZero()
        {
            var array1 = new int?[] { 0, 1, 2, 3 };
            var array2 = new int?[] { null, 1, 2, 3 };
            const int ExpectedResult = 0;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void GivenConsectiveNumbersWithZero()
        {
            var array1 = new int?[] { 0, 1, 2, 3 };
            var array2 = new int?[] { 0, 1, null, 3 };
            const int ExpectedResult = 2;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void GivenConsectiveNumbersWithZeroOutOfOrder()
        {
            var array1 = new int?[] { 3, 1, 2, 0 };
            var array2 = new int?[] { 0, 1, 3, null };
            const int ExpectedResult = 2;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void IntMax()
        {
            var array1 = new int?[] { 1, int.MaxValue, 60, 32 };
            var array2 = new int?[] { 1, 60, null, 32 };
            const int ExpectedResult = int.MaxValue;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void IntMin()
        {
            var array1 = new int?[] { 1, int.MinValue, 60, 32 };
            var array2 = new int?[] { 1, 60, null, 32 };
            const int ExpectedResult = int.MinValue;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void NegativeNumbers()
        {
            var array1 = new int?[] { -10, 20, 60, 32 };
            var array2 = new int?[] { null, 60, 20, 32 };
            const int ExpectedResult = -10;

            AssertResults(array1, array2, ExpectedResult);
        }

        [Fact]
        public void NonConsectiveNumbersOutOfOrder()
        {
            var array1 = new int?[] { 10, 20, 60, 32 };
            var array2 = new int?[] { null, 60, 20, 32 };
            const int ExpectedResult = 10;

            AssertResults(array1, array2, ExpectedResult);
        }

        #endregion

        #region Methods

        private static void AssertResults(int?[] array1, int?[] array2, int expectedResult)
        {
            var actualResult = MissingElementFinder.GetMissingElement(array1, array2);

            expectedResult.Should().Be(actualResult);
        }

        #endregion
    }
}