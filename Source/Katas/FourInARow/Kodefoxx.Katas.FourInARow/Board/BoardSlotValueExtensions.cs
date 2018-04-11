using System.Collections.Generic;
using System.Linq;

namespace Kodefoxx.Katas.FourInARow.Board
{
    public static class BoardSlotValueExtensions
    {
        /// <summary>
        /// Converts a 2d array of <see cref="BoardSlotValue"/> to a <see cref="BoardSize"/>.
        /// </summary>        
        public static BoardSize ToBoardSize(this BoardSlotValue[,] boardSlotValues)
            => new BoardSize(
                width: boardSlotValues.GetUpperBound(1) + 1, 
                height: boardSlotValues.GetUpperBound(0) + 1
            )
        ;

        /// <summary>
        /// Converts a 2d array of <see cref="BoardSlotValue"/> to an enumerable of <see cref="BoardSlot"/>.
        /// </summary>        
        public static IEnumerable<BoardSlot> ToBoardSlots(this BoardSlotValue[,] boardSlotValues)
        {
            var boardSize = boardSlotValues.ToBoardSize();
            for (var rowIndex = 0; rowIndex < boardSize.Height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < boardSize.Width; columnIndex++)
                    yield return new BoardSlot(
                        boardSlotValues[rowIndex, columnIndex],
                        new BoardPosition(rowIndex + 1, columnIndex + 1)
                    );
            }
        }            
    }
}
