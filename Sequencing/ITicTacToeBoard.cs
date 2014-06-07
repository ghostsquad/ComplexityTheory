// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITicTacToeBoard.cs" company="">
//   
// </copyright>
// <summary>
//   The TicTacToeBoard interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sequencing
{
    using System.Collections.Generic;

    /// <summary>
    ///     The TicTacToeBoard interface.
    /// </summary>
    public interface ITicTacToeBoard
    {
        #region Public Properties

        /// <summary>
        ///     Gets the values.
        /// </summary>
        List<List<TicTacToePlayers?>> Values { get; }

        #endregion
    }
}