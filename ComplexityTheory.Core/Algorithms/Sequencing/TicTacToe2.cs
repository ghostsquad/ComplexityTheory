namespace ComplexityTheory.Core.Algorithms.Sequencing
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The tic tac toe 2.
    /// </summary>
    public class TicTacToe2 : ITicTacToe
    {
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
        /// If gameBoard is null.
        /// </exception>
        public TicTacToePlayers? GetWinner(ITicTacToeBoard gameBoard)
        {
            if (gameBoard == null)
            {
                throw new ArgumentNullException("gameBoard");
            }

            TicTacToePlayers? possibleDiagonalLeanRightWinner = null;
            TicTacToePlayers? possibleDiagonalLeanLeftWinner = null;
            var possibleColumnWinners = new List<TicTacToePlayers?>(3) { null, null, null };

            for (int row = 0; row < 3; row++)
            {
                TicTacToePlayers? possibleRowWinner = null;

                for (int column = 0; column < 3; column++)
                {
                    TicTacToePlayers? currentSpotOccupiedBy = gameBoard.Values[row][column];

                    // analyze horizontal
                    if (column == 0 && currentSpotOccupiedBy != null)
                    {
                        possibleRowWinner = currentSpotOccupiedBy;
                    }
                    else if (currentSpotOccupiedBy != possibleRowWinner)
                    {
                        possibleRowWinner = null;
                    }
                    else if (possibleRowWinner != null && column == 2)
                    {
                        return possibleRowWinner;
                    }

                    // analyze vertical
                    TicTacToePlayers? possibleColumnWinner = possibleColumnWinners[column];
                    if (row == 0)
                    {
                        possibleColumnWinners[column] = currentSpotOccupiedBy;
                    }
                    else if (currentSpotOccupiedBy != possibleColumnWinner)
                    {
                        possibleColumnWinners[column] = null;
                    }
                    else if (possibleColumnWinner != null && row == 2)
                    {
                        return possibleColumnWinner;
                    }

                    // analyze diagonal lean left
                    if (column == row)
                    {
                        if (column == 0)
                        {
                            possibleDiagonalLeanLeftWinner = currentSpotOccupiedBy;
                        }
                        else if (currentSpotOccupiedBy != possibleDiagonalLeanLeftWinner)
                        {
                            possibleDiagonalLeanLeftWinner = null;
                        }
                        else if (possibleDiagonalLeanLeftWinner != null && column == 2)
                        {
                            return possibleDiagonalLeanLeftWinner;
                        }
                    }

                    // analyze diagonal lean right
                    if (column == row || Math.Abs(row - column) == 2)
                    {
                        if (column == 2)
                        {
                            possibleDiagonalLeanRightWinner = currentSpotOccupiedBy;
                        }
                        else if (currentSpotOccupiedBy != possibleDiagonalLeanRightWinner)
                        {
                            possibleDiagonalLeanRightWinner = null;
                        }
                        else if (possibleDiagonalLeanRightWinner != null && column == 0)
                        {
                            return possibleDiagonalLeanRightWinner;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }
}