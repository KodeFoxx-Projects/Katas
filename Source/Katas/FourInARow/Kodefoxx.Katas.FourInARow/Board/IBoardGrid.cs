using Kodefoxx.Katas.FourInARow.Board.Winning;

namespace Kodefoxx.Katas.FourInARow.Board
{
    /// <summary>
    /// Represents the 2d grid board the game is played on.
    /// </summary>
    public interface IBoardGrid : IReadOnlyBoardGrid
    {
        /// <summary>
        /// Drops a value into the specified column of the board.
        /// </summary>
        /// <param name="boardSlotValue">The value to drop.</param>
        /// <param name="columnIndex">The index of the column to drop into.</param>        
        IReadOnlyBoardGrid DropValueIntoColumn(BoardSlotValue boardSlotValue, int columnIndex);

        /// <summary>
        /// Determines whether a given column is full.
        /// </summary>
        /// <param name="columnIndex">The index of the column to check.</param>        
        bool IsColumnFull(int columnIndex);

        /// <summary>
        /// Determines whether the board is full.
        /// </summary>        
        bool IsBoardFull();

        /// <summary>
        /// Determines whether the board has a winner.
        /// </summary>        
        bool HasWinner();

        /// <summary>
        /// Calculates the <see cref="WinState"/>.
        /// </summary>       
        WinState GetWinState();
    }
}
