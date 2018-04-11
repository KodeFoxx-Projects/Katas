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
    }
}
