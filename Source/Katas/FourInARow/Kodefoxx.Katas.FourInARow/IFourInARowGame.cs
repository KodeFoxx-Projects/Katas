using Kodefoxx.Katas.FourInARow.Board;
using Kodefoxx.Katas.FourInARow.Players;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow
{
    /// <summary>
    /// Represents an four in a row game.
    /// </summary>
    public interface IFourInARowGame
    {
        /// <summary>
        /// Player one.
        /// </summary>
        Player PlayerOne { get; }

        /// <summary>
        /// Player two.
        /// </summary>
        Player PlayerTwo { get; }

        /// <summary>
        /// Gets the current player's turn.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        /// The board (read only).
        /// </summary>
        IReadOnlyBoardGrid Board { get; }

        /// <summary>
        /// Determines whether the board has a winner.
        /// </summary>        
        bool HasWinner();

        /// <summary>
        /// Calculates the <see cref="WinState"/>.
        /// </summary>       
        WinState GetWinState();

        /// <summary>
        /// Drops a value into the specified column of the board.
        /// </summary>        
        /// <param name="columnIndex">The index of the column to drop into.</param>        
        WinState PlayValueInColumn(int columnIndex);
    }
}
