using System;

namespace Kodefoxx.Katas.FourInARow.Board.Exceptions
{
    public class ColumnException : Exception
    {
        public ColumnException(
            int columnIndex, string message, Exception innerException = null
        ) : base(message: message, innerException: innerException)
            => ColumnIndex = columnIndex;

        public int ColumnIndex { get; }
    }
}
