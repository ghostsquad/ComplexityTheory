// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicTacToeTests.cs" company="">
// </copyright>
// <summary>
//   The tic tac toe tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ComplexityTheory.Test.Algorithms.Sequencing
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using ComplexityTheory.Core.Algorithms.Sequencing;

    using FluentAssertions;

    using Xunit;

    /// <summary>
    ///     The tic tac toe tests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class TicTacToeTestBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the tic tac toe algorithm.
        /// </summary>
        protected ITicTacToe TicTacToeAlgorithm { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The given cat game expect null winner.
        /// </summary>
        [Fact]
        public void GivenCatGameExpectNullWinner()
        {
            // arrange            
            var boardScenario = new TicTacToeBoard();
            boardScenario.Values[0] = new List<TicTacToePlayers?>
                                          {
                                              TicTacToePlayers.X, 
                                              TicTacToePlayers.O, 
                                              TicTacToePlayers.X
                                          };
            boardScenario.Values[1] = new List<TicTacToePlayers?>
                                          {
                                              TicTacToePlayers.O, 
                                              TicTacToePlayers.O, 
                                              TicTacToePlayers.X
                                          };
            boardScenario.Values[2] = new List<TicTacToePlayers?>
                                          {
                                              TicTacToePlayers.X, 
                                              TicTacToePlayers.X, 
                                              TicTacToePlayers.O
                                          };

            // act
            TicTacToePlayers? winner = this.TicTacToeAlgorithm.GetWinner(boardScenario);

            // assert
            winner.Should().BeNull();
        }

        /// <summary>
        ///     The given diagonal o win expect o winner.
        /// </summary>
        [Fact]
        public void GivenDiagonalLeanLeftOWinExpectOWinner()
        {
            this.AssertWinner(TicTacToePlayers.O, GetDiagonalLeanLeftWin(TicTacToePlayers.O));
        }

        /// <summary>
        ///     The given diagonal x win expect x winner.
        /// </summary>
        [Fact]
        public void GivenDiagonalLeanLeftXWinExpectXWinner()
        {
            this.AssertWinner(TicTacToePlayers.X, GetDiagonalLeanLeftWin(TicTacToePlayers.X));
        }

        /// <summary>
        ///     The given diagonal lean right o win expect o winner.
        /// </summary>
        [Fact]
        public void GivenDiagonalLeanRightOWinExpectOWinner()
        {
            this.AssertWinner(TicTacToePlayers.O, GetDiagonalLeanRightWin(TicTacToePlayers.O));
        }

        /// <summary>
        ///     The given diagonal lean right x win expect x winner.
        /// </summary>
        [Fact]
        public void GivenDiagonalLeanRightXWinExpectXWinner()
        {
            this.AssertWinner(TicTacToePlayers.X, GetDiagonalLeanRightWin(TicTacToePlayers.X));
        }

        /// <summary>
        ///     The given horizontal o win expect o winner.
        /// </summary>
        [Fact]
        public void GivenHorizontalOWinExpectOWinner()
        {
            this.AssertWinner(TicTacToePlayers.O, GetHorizontalWin(TicTacToePlayers.O));
        }

        /// <summary>
        ///     The given horizontal x win expect x winner.
        /// </summary>
        [Fact]
        public void GivenHorizontalXWinExpectXWinner()
        {
            this.AssertWinner(TicTacToePlayers.X, GetHorizontalWin(TicTacToePlayers.X));
        }

        /// <summary>
        ///     The given incomplete game expect null winner.
        /// </summary>
        [Fact]
        public void GivenIncompleteGameExpectNullWinner()
        {
            // arrange
            var boardScenario = new TicTacToeBoard();
            boardScenario.Values[0][0] = TicTacToePlayers.O;
            boardScenario.Values[1][1] = TicTacToePlayers.X;

            // act
            TicTacToePlayers? winner = this.TicTacToeAlgorithm.GetWinner(boardScenario);

            // assert
            winner.Should().BeNull();
        }

        /// <summary>
        ///     The given not started game expect null winner.
        /// </summary>
        [Fact]
        public void GivenNotStartedGameExpectNullWinner()
        {
            // arrange
            var boardScenario = new TicTacToeBoard();

            // act
            TicTacToePlayers? winner = this.TicTacToeAlgorithm.GetWinner(boardScenario);

            // assert
            winner.Should().BeNull();
        }

        /// <summary>
        ///     The given null input expect exception.
        /// </summary>
        [Fact]
        public void GivenNullInputExpectException()
        {
            // arrange & act
            this.TicTacToeAlgorithm.Invoking(x => x.GetWinner(null)).ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        ///     The given vertical o win expect o winner.
        /// </summary>
        [Fact]
        public void GivenVerticalOWinExpectOWinner()
        {
            this.AssertWinner(TicTacToePlayers.O, GetVerticalWin(TicTacToePlayers.O));
        }

        /// <summary>
        ///     The given vertical x win expect x winner.
        /// </summary>
        [Fact]
        public void GivenVerticalXWinExpectXWinner()
        {
            this.AssertWinner(TicTacToePlayers.X, GetVerticalWin(TicTacToePlayers.X));
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get diagonal win.
        /// </summary>
        /// <param name="winningPlayer">
        /// The winning player.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToeBoard"/>.
        /// </returns>
        private static TicTacToeBoard GetDiagonalLeanLeftWin(TicTacToePlayers winningPlayer)
        {
            var boardScenario = new TicTacToeBoard();
            for (int i = 0; i < 3; i++)
            {
                boardScenario.Values[i][i] = winningPlayer;
            }

            return boardScenario;
        }

        /// <summary>
        /// The get diagonal lean right win.
        /// </summary>
        /// <param name="winningPlayer">
        /// The winning player.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToeBoard"/>.
        /// </returns>
        private static TicTacToeBoard GetDiagonalLeanRightWin(TicTacToePlayers winningPlayer)
        {
            var boardScenario = new TicTacToeBoard();
            for (int i = 2; i >= 0; i--)
            {
                boardScenario.Values[2 - i][i] = winningPlayer;
            }

            return boardScenario;
        }

        /// <summary>
        /// The get horizontal win.
        /// </summary>
        /// <param name="winningPlayer">
        /// The winning player.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToeBoard"/>.
        /// </returns>
        private static TicTacToeBoard GetHorizontalWin(TicTacToePlayers winningPlayer)
        {
            var boardScenario = new TicTacToeBoard();
            boardScenario.Values[2] = new List<TicTacToePlayers?> { winningPlayer, winningPlayer, winningPlayer };

            return boardScenario;
        }

        /// <summary>
        /// The get vertical win.
        /// </summary>
        /// <param name="winningPlayer">
        /// The winning player.
        /// </param>
        /// <returns>
        /// The <see cref="TicTacToeBoard"/>.
        /// </returns>
        private static TicTacToeBoard GetVerticalWin(TicTacToePlayers winningPlayer)
        {
            var boardScenario = new TicTacToeBoard();
            boardScenario.Values[0][2] = winningPlayer;
            boardScenario.Values[1][2] = winningPlayer;
            boardScenario.Values[2][2] = winningPlayer;

            return boardScenario;
        }

        /// <summary>
        /// The assert winner.
        /// </summary>
        /// <param name="expectedWinner">
        /// The expected winner.
        /// </param>
        /// <param name="boardScenario">
        /// The board scenario.
        /// </param>
        private void AssertWinner(TicTacToePlayers expectedWinner, TicTacToeBoard boardScenario)
        {
            TicTacToePlayers? actualwinner = this.TicTacToeAlgorithm.GetWinner(boardScenario);
            actualwinner.Should().Be(expectedWinner);
        }

        #endregion
    }
}