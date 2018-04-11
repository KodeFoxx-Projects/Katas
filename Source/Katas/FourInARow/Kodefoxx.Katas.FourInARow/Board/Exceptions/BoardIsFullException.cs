using System;

namespace Kodefoxx.Katas.FourInARow.Board.Exceptions
{
    public sealed class BoardIsFullException : BoardException
    {
        public BoardIsFullException() 
            : base("Board is full.")
        { }
    }
}
