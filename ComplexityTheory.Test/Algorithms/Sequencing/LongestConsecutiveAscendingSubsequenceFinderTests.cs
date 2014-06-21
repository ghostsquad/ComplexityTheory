// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LongestConsecutiveAscendingSubsequenceFinderTests.cs" company="">
//   
// </copyright>
// <summary>
//   The longest consecutive ascending subsequence finder tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ComplexityTheory.Test.Algorithms.Sequencing
{
    using System.Collections.Generic;

    using ComplexityTheory.Core.Algorithms.Sequencing;

    using FluentAssertions;

    using Xunit;

    /// <summary>
    ///     The longest consecutive ascending subsequence finder tests.
    /// </summary>
    public class LongestConsecutiveAscendingSubsequenceFinderTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The given array list with length one expect no sequence found.
        /// </summary>
        [Fact]
        public void GivenArrayListWithLengthOneExpectNoSequenceFound()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 0 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            Assert.Null(actualSubSequence);
        }

        /// <summary>
        ///     The given ascending consecutives.
        /// </summary>
        [Fact]
        public void GivenAscendingConsecutives()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 0, 1 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(sequence);
        }

        /// <summary>
        ///     The given descending consecutives.
        /// </summary>
        [Fact]
        public void GivenDescendingConsecutives()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 2, 1, 0 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().BeNull();
        }

        /// <summary>
        ///     The given empty array.
        /// </summary>
        [Fact]
        public void GivenEmptyArray()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int>();

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().BeNull();
        }

        /// <summary>
        ///     The given multiple sequences of different lengths expect larger.
        /// </summary>
        [Fact]
        public void GivenLargerSequenceAfterSmallSequenceExpectLarger()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 1, 2, 0, 3, 4, 5 };
            var expectedSequence = new List<int> { 3, 4, 5 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(expectedSequence);
        }

        /// <summary>
        ///     The given larger sequence before small sequence expect larger.
        /// </summary>
        [Fact]
        public void GivenLargerSequenceBeforeSmallSequenceExpectLarger()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 1, 2, 3, 0, 4, 5 };
            var expectedSequence = new List<int> { 1, 2, 3 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(expectedSequence);
        }

        /// <summary>
        ///     The given larger sequence immediately after smaller sequence expect larger.
        /// </summary>
        [Fact]
        public void GivenLargerSequenceImmediatelyAfterSmallerSequenceExpectLarger()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 1, 2, 4, 5, 6 };
            var expectedSequence = new List<int> { 4, 5, 6 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(expectedSequence);
        }

        /// <summary>
        ///     The given multiple sequences of same length expect first.
        /// </summary>
        [Fact]
        public void GivenMultipleSequencesOfSameLengthExpectFirst()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 1, 2, 0, 3, 4 };
            var expectedSequence = new List<int> { 1, 2 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(expectedSequence);
        }

        /// <summary>
        ///     The given negative consecutive increasing numbers.
        /// </summary>
        [Fact]
        public void GivenNegativeConsecutiveIncreasingNumbers()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { -2, -1 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().Equal(sequence);
        }

        /// <summary>
        ///     The given non consecutive numbers.
        /// </summary>
        [Fact]
        public void GivenNonConsecutiveNumbers()
        {
            // arrange
            ISequenceFinder sequenceFinder = new LongestConsecutiveAscendingSubsequenceFinder();
            var sequence = new List<int> { 0, 2, 4 };

            // act
            List<int> actualSubSequence = sequenceFinder.GetSubSequence(sequence);

            // assert
            actualSubSequence.Should().BeNull();
        }

        #endregion
    }
}