using System;
using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Board.Exceptions;
using Kodefoxx.Katas.FourInARow.Players;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow
{
    public sealed class FourInARowGame : IFourInARowGame
    {
        private readonly PlayerSwitcher _playerSwitcher;
        private readonly IBoardGrid _boardGrid;

        /// <summary>
        /// Creates a new <see cref="FourInARowGame"/>.
        /// </summary>
        /// <param name="playerOne">Name of player one.</param>
        /// <param name="playerTwo">Name of player two.</param>
        /// <param name="boardSize">The <see cref="BoardSize"/>.</param>
        public FourInARowGame(string playerOneName, string playerTwoName, BoardSize boardSize)
        {
            PlayerOne = new Player(playerOneName, BoardSlotValue.P1);
            PlayerTwo = new Player(playerTwoName, BoardSlotValue.P2);
            _boardGrid = new BoardGrid(boardSize);
            _playerSwitcher = new PlayerSwitcher(new []{ PlayerOne, PlayerTwo });
        }

        /// <inheritdocs/>
        public Player PlayerOne { get; }

        /// <inheritdocs/>
        public Player PlayerTwo { get; }

        public Player CurrentPlayer
            => _playerSwitcher.CurrentPlayer;

        /// <inheritdocs/>
        public IReadOnlyBoardGrid Board 
            => _boardGrid;

        /// <inheritdocs/>
        public bool HasWinner()
            => _boardGrid.HasWinner();

        /// <inheritdocs/>
        public WinState GetWinState()
            => _boardGrid.GetWinState();

        /// <inheritdocs/>
        public WinState PlayValueInColumn(int columnIndex)
        {
            var boardSlotValue = CurrentPlayer.Type;
            var winState = GetWinState();

            try
            {
                _boardGrid.DropValueIntoColumn(boardSlotValue, columnIndex);                
                _playerSwitcher.NextPlayer();
                return GetWinState();
            }
            catch (BoardIsFullException boardIsFullException) { }
            catch (ColumnIsFullException columnIsFullException) { }
            catch (Exception ex) { }
            finally
            {
                winState = GetWinState();
            }

            return winState;
        }
    }
}
