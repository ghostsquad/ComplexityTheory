// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LongestConsecutiveAscendingSubsequenceFinder.cs" company="">
//   
// </copyright>
// <summary>
//   The longest consecutive ascending subsequence finder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sequencing
{
    using System.Collections.Generic;

    /// <summary>
    ///     The longest consecutive ascending subsequence finder.
    /// </summary>
    public class LongestConsecutiveAscendingSubsequenceFinder : ISequenceFinder
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get sub sequence.
        /// </summary>
        /// <param name="mainSequence">
        /// The main sequence.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<int> GetSubSequence(List<int> mainSequence)
        {
            var largestSequence = new List<int>();

            var currentSequence = new List<int>();

            foreach (int value in mainSequence)
            {
                if (!(currentSequence.Count == 0 || currentSequence[currentSequence.Count - 1] + 1 == value))
                {
                    currentSequence.Clear();
                }

                currentSequence.Add(value);

                if (currentSequence.Count > 1 && currentSequence.Count > largestSequence.Count)
                {
                    largestSequence.Clear();
                    largestSequence.AddRange(currentSequence);
                }
            }

            return largestSequence.Count > 1 ? largestSequence : null;
        }

        #endregion
    }
}