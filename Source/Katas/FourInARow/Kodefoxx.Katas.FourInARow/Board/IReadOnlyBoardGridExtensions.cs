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

        /// <summary>
        /// Gets all the <see cref="BoardSlot"/>-lines from top to bottom.
        /// </summary>
        public static IDictionary<int, IEnumerable<BoardSlot>> GetBoardSlotDiagonalTopToBottomLines(this IReadOnlyBoardGrid boardGrid)
        {
            var boardPositionsCollection = new List<List<BoardPosition>>()
                .Concat(GetPositionsTopToBottomLeftHalf(boardGrid))
                .Concat(GetPositionsTopToBottomRightHalf(boardGrid));

            var boardSlotsCollection = boardPositionsCollection
                .Select(boardPositions =>                
                    boardPositions
                        .Select(boardPosition => boardGrid.State.SingleOrDefault(slot => slot.Position.Equals(boardPosition)))
                        .Where(slot => slot != null)
                )
                .ToList();

            return boardSlotsCollection.Select((boardSlots, i) => new { BoardSlots = boardSlots, Index = i})
                .ToDictionary(
                    keySelector: kvp => kvp.Index,
                    elementSelector: kvp => kvp.BoardSlots
                );
        }

        /// <summary>
        /// Calculate <see cref="BoardPosition"/>s starting from the top with the row as start and the row as limiter.
        /// </summary>
        private static IEnumerable<List<BoardPosition>> GetPositionsTopToBottomLeftHalf(IReadOnlyBoardGrid boardGrid)
        {            
            foreach (var rowIndex in Enumerable.Range(1, boardGrid.Rows))
            {
                var boardPositions = new List<BoardPosition>();
                for (var adder = 1; adder <= boardGrid.Columns; adder++)
                {
                    var calculatedRow = (rowIndex - 1) + adder;
                    if (calculatedRow <= boardGrid.Rows)
                    {
                        boardPositions.Add(new BoardPosition(
                            row: calculatedRow,
                            column: adder)
                        );
                    }
                }
                yield return boardPositions;
            }
        }

        /// <summary>
        /// Calculate <see cref="BoardPosition"/>s starting from the column with the column as start and the row as limiter.
        /// </summary>
        private static IEnumerable<List<BoardPosition>> GetPositionsTopToBottomRightHalf(IReadOnlyBoardGrid boardGrid)
        {
            foreach (var columnIndex in Enumerable.Range(1, boardGrid.Columns))
            {
                var boardPositions = new List<BoardPosition>();
                for (var adder = 1; adder <= boardGrid.Rows; adder++)
                {
                    var calculatedColumn = (columnIndex - 1) + adder;
                    if (calculatedColumn <= boardGrid.Columns)
                    {
                        boardPositions.Add(new BoardPosition(
                            row: adder,
                            column: calculatedColumn)
                        );
                    }
                }
                yield return boardPositions;
            }
        }
    }
}
