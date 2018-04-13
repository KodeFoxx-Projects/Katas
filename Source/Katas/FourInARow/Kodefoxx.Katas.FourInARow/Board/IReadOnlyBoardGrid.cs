using System.Collections.Generic;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow.Board
{
    /// <summary>
    /// Represents the 2d board grid for read-only purposes.
    /// </summary>
    public interface IReadOnlyBoardGrid
    {
        /// <summary>
        /// Gets the state of the board.
        /// </summary>
        IReadOnlyList<BoardSlot> State { get; }

        /// <summary>
        /// The number of rows (or the height) of the board.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// The number of columns (or the width) of the board.
        /// </summary>
        int Columns { get; }        
    }
}
