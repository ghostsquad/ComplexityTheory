// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISequenceFinder.cs" company="">
//   
// </copyright>
// <summary>
//   The SequenceFinder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sequencing
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    ///     The SequenceFinder interface.
    /// </summary>
    public interface ISequenceFinder
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get sub sequence.
        /// </summary>
        /// <param name="mainSequence">
        /// The main sequence.
        /// </param>
        /// <returns>
        /// The <see cref="ArrayList"/>.
        /// </returns>
        List<int> GetSubSequence(List<int> mainSequence);

        #endregion
    }
}