// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicTacToe.cs" company="">
//   
// </copyright>
// <summary>
//   The tic tac toe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ComplexityTheory.Core.Algorithms.Sequencing
{
    using System;

    /// <summary>
    ///     The tic tac toe.
    /// </summary>
    public class TicTacToe : ITicTacToe
    {
        #region Fields

        /// <summary>
        ///     The game board.
        /// </summary>
        private ITicTacToeBoard gameBoardInternal;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get winner.
        /// </summary>
        /// <param name="gameBoard">
        /// The game board.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToePlayers?"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// When gameBoard is null.
        /// </exception>
        public TicTacToePlayers? GetWinner(ITicTacToeBoard gameBoard)
        {
            if (gameBoard == null)
            {
                throw new ArgumentNullException("gameBoard");
            }

            this.gameBoardInternal = gameBoard;

            TicTacToePlayers? cellOccupiedBy;

            for (int column = 0; column < 3; column++)
            {
                cellOccupiedBy = gameBoard.Values[0][column];

                if (cellOccupiedBy != null)
                {
                    if (this.CheckVerticalPlayersIdentical((TicTacToePlayers)cellOccupiedBy, column)
                        || (column == 0 && this.CheckDiagonalLeanLeftIdentical((TicTacToePlayers)cellOccupiedBy))
                        || (column == 2 && this.CheckDiagonalLeanRightIdentical((TicTacToePlayers)cellOccupiedBy)))
                    {
                        return cellOccupiedBy;
                    }
                }
            }

            for (int row = 0; row < 3; row++)
            {
                cellOccupiedBy = gameBoard.Values[row][0];

                if (cellOccupiedBy != null && this.CheckHorizontalIdentical((TicTacToePlayers)cellOccupiedBy, row))
                {
                    return cellOccupiedBy;
                }
            }

            return null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The check diagonal lean left identical.
        /// </summary>
        /// <param name="expectedPlayer">
        /// The expected player.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckDiagonalLeanLeftIdentical(TicTacToePlayers expectedPlayer)
        {
            for (int i = 1; i < 3; i++)
            {
                if (this.gameBoardInternal.Values[i][i] != expectedPlayer)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The check diagonal lean right identical.
        /// </summary>
        /// <param name="expectedPlayer">
        /// The expected player.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckDiagonalLeanRightIdentical(TicTacToePlayers expectedPlayer)
        {
            for (int i = 1; i >= 0; i--)
            {
                if (this.gameBoardInternal.Values[2 - i][i] != expectedPlayer)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The check horizontal identical.
        /// </summary>
        /// <param name="expectedPlayer">
        /// The expected player.
        /// </param>
        /// <param name="currentRow">
        /// The current row.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckHorizontalIdentical(TicTacToePlayers expectedPlayer, int currentRow)
        {
            for (int column = 1; column < 3; column++)
            {
                if (this.gameBoardInternal.Values[currentRow][column] != expectedPlayer)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The check vertical players identical.
        /// </summary>
        /// <param name="expectedPlayer">
        /// The expected player.
        /// </param>
        /// <param name="currentCol">
        /// The current col.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckVerticalPlayersIdentical(TicTacToePlayers expectedPlayer, int currentCol)
        {
            for (int row = 1; row < 3; row++)
            {
                if (this.gameBoardInternal.Values[row][currentCol] != expectedPlayer)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}