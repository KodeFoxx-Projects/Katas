using System;

namespace Kodefoxx.Katas.FourInARow.Board.Exceptions
{
    public class BoardException : Exception
    {
        public BoardException(string message, Exception innException = null)
            : base(message, innException)
        { }
    }
}
