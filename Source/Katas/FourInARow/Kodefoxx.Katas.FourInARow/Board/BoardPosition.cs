using System.Diagnostics;
using System.Runtime.Serialization;

namespace Kodefoxx.Katas.FourInARow.Board
{
    [DebuggerDisplay("C:{Column}R:{Row}")]
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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is BoardPosition boardPosition)) return false;

            return
                boardPosition.GetHashCode() == GetHashCode()
             && boardPosition.Row == Row
             && boardPosition.Column == Column;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Row.GetHashCode();
                hash = hash * 23 + Column.GetHashCode();
                return hash;
            }
        }
    }
}
