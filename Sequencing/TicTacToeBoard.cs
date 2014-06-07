// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicTacToeBoard.cs" company="">
//   
// </copyright>
// <summary>
//   The tic tac toe board.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Sequencing
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     The tic tac toe board.
    /// </summary>
    public class TicTacToeBoard : ITicTacToeBoard
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TicTacToeBoard" /> class.
        /// </summary>
        public TicTacToeBoard()
        {
            this.Values = new List<List<TicTacToePlayers?>>(3)
                              {
                                  Enumerable.Repeat((TicTacToePlayers?)null, 3).ToList(), 
                                  Enumerable.Repeat((TicTacToePlayers?)null, 3).ToList(), 
                                  Enumerable.Repeat((TicTacToePlayers?)null, 3).ToList(), 
                              };
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the values.
        /// </summary>
        public List<List<TicTacToePlayers?>> Values { get; private set; }

        #endregion
    }
}