using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.FourInARow.Board
{
    public static class IReadOnlyBoardGridExtensions
    {
        /// <summary>
        /// Converts a <see cref="IReadOnlyBoardGrid"/> to a <see cref="BoardSize"/>.
        /// </summary>
        /// <param name="boardGrid">The <see cref="IReadOnlyBoardGrid"/> to get the <see cref="BoardSize"/> from.</param>        
        public static BoardSize ToBoardSize(this IReadOnlyBoardGrid boardGrid)
            => new BoardSize(width: boardGrid.Columns, height: boardGrid.Rows);

        /// <summary>
        /// Gets the <see cref="BoardSlot"/>s for a given <paramref name="columnIndex"/>.
        /// </summary>
        /// <param name="boardGrid">The <see cref="IReadOnlyBoardGrid"/> to get the <see cref="BoardSlot"/> values from.</param>
        /// <param name="columnIndex">The targetted 1-based column index.</param>
        /// <returns></returns>
        public static IEnumerable<BoardSlot> GetBoardSlotsForColumn(
            this IReadOnlyBoardGrid boardGrid, int columnIndex
        ) => boardGrid
                .State
                .Where(slot => slot.Position.Column == columnIndex);

        /// <summary>
        /// Gets the <see cref="BoardSlot"/>s for a given <paramref name="rowIndex"/>.
        /// </summary>
        /// <param name="boardGrid">The <see cref="IReadOnlyBoardGrid"/> to get the <see cref="BoardSlot"/> values from.</param>
        /// <param name="rowIndex">The targetted 1-based row index.</param>
        /// <returns></returns>
        public static IEnumerable<BoardSlot> GetBoardSlotsForRow(
            this IReadOnlyBoardGrid boardGrid, int rowIndex
        ) => boardGrid
            .State
            .Where(slot => slot.Position.Row == rowIndex);

        /// <summary>
        /// Gets all the <see cref="BoardSlot"/>s grouped by column index.
        /// </summary>                
        public static IDictionary<int, IEnumerable<BoardSlot>> GetBoardSlotColumns(this IReadOnlyBoardGrid boardGrid)
            => Enumerable.Range(1, boardGrid.Columns)
                .ToDictionary(
                    keySelector: columnIndex => columnIndex,
                    elementSelector: boardGrid.GetBoardSlotsForColumn
                )
        ;

        /// <summary>
        /// Gets all the <see cref="BoardSlot"/>s grouped by row index.
        /// </summary>                
        public static IDictionary<int, IEnumerable<BoardSlot>> GetBoardSlotRows(this IReadOnlyBoardGrid boardGrid)
            => Enumerable.Range(1, boardGrid.Rows)
                .ToDictionary(
                    keySelector: rowIndex => rowIndex,
                    elementSelector: boardGrid.GetBoardSlotsForRow
                )
        ;


    }
}
