namespace Kodefoxx.Katas.FourInARow.Board
{
    public sealed class BoardSlot
    {
        /// <summary>
        /// Creates a new <see cref="BoardSlot"/> based on the given <paramref name="value"/> and the position by the 1-based <paramref name="rowIndex"/> and the 1-based <paramref name="columnIndex"/>.
        /// </summary>
        /// <param name="value">The value the slot holds.</param>
        /// <param name="rowIndex">The 1-based index of the row the slot is positioned at.</param>
        /// <param name="columnIndex">The 1-based index of the column the slot is positioned at.</param>
        internal BoardSlot(BoardSlotValue value, int rowIndex, int columnIndex)
            : this(value, new BoardPosition(rowIndex, columnIndex))
        { }

        /// <summary>
        /// Creates a new <see cref="BoardSlot"/> based on the given <paramref name="value"/> and <paramref name="position"/>.
        /// </summary>
        /// <param name="value">The value the slot holds.</param>
        /// <param name="position">The position of the slot.</param>
        internal BoardSlot(BoardSlotValue value, BoardPosition position)
        {
            Value = value;
            Position = position;
        }

        /// <summary>
        /// The value of this slot.
        /// </summary>
        public BoardSlotValue Value { get; }

        /// <summary>
        /// The position of this slot.
        /// </summary>
        public BoardPosition Position { get; set; }
    }
}
