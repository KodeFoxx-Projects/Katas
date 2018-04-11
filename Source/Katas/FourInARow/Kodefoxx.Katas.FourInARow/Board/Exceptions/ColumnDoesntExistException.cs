namespace Kodefoxx.Katas.FourInARow.Board.Exceptions
{
    public sealed class ColumnDoesntExistException : ColumnException
    {
        public ColumnDoesntExistException(int columnIndex)
            : base(columnIndex, $"Column {columnIndex} does not exist.")
        { }
    }
}
