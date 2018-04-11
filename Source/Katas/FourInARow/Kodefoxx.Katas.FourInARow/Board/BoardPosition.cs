namespace Kodefoxx.Katas.FourInARow.Board
{
    public sealed class BoardPosition
    {
        /// <summary>
        /// Creates a new <see cref="BoardPosition"/>.
        /// </summary>
        /// <param name="row">The index of the row.</param>
        /// <param name="column">The index of the column.</param>
        internal BoardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// The index of the row.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// The index of the column.
        /// </summary>
        public int Column { get; }
    }
}
