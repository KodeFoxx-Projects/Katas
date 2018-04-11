namespace Kodefoxx.Katas.FourInARow.Board.Exceptions
{
    public sealed class ColumnIsFullException : ColumnException
    {
        public ColumnIsFullException(int columnIndex) 
            : base(columnIndex, $"Column {columnIndex} is full.")
        { }
    }
}
