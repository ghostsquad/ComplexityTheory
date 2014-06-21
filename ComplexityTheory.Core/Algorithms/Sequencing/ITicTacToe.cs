// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITicTacToe.cs" company="">
//   
// </copyright>
// <summary>
//   The TicTacToe interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ComplexityTheory.Core.Algorithms.Sequencing
{
    /// <summary>
    ///     The TicTacToe interface.
    /// </summary>
    public interface ITicTacToe
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get winner.
        /// </summary>
        /// <param name="gameBoard">
        /// The game grid.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToePlayers"/>.
        /// </returns>
        TicTacToePlayers? GetWinner(ITicTacToeBoard gameBoard);

        #endregion
    }
}