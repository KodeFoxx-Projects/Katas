using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FourInARow.Board.Exceptions;
using Kodefoxx.Katas.FourInARow.Winning;

namespace Kodefoxx.Katas.FourInARow.Board
{
    /// <summary>
    /// Represents the board's 2d grid.
    /// </summary>
    public sealed class BoardGrid : 
        ReadOnlyBoardGrid, IBoardGrid
    {
        /// <inheritdocs/>
        internal BoardGrid(int width, int height) 
            : base(width, height)
        { }

        /// <inheritdocs/>
        internal BoardGrid(BoardSize boardSize) 
            : base(boardSize)
        { }

        /// <inheritdocs/>
        internal BoardGrid(BoardSlotValue[,] boardSlotValues) 
            : base(boardSlotValues)
        { }

        /// <inheritdocs/>
        public bool IsColumnFull(int columnIndex)
        {
            if(!DoesColumnIndexExist(columnIndex))
                throw new ColumnDoesntExistException(columnIndex);

            return State
                .Where(slot => slot.Position.Column == columnIndex)
                .All(slot => slot.Value != BoardSlotValue.Empty);
        }

        /// <inheritdocs/>
        public bool IsBoardFull()
            => State
                .All(slot => slot.Value != BoardSlotValue.Empty);

        /// <inheritdocs/>
        public bool HasWinner()
            => GetWinState().HasWinner;

        /// <inheritdocs/>
        public WinState GetWinState()
        {
            var winState = new WinState(WinMethod.None);

            foreach (var winStateCalculator in _winStateCalculators)
            {
                var result = winStateCalculator.Calculate(this);
                if(result.Winner.HasValue)
                    winState = new WinState(result.Method, result.Winner);
            }

            if(IsBoardFull() && winState.Method == WinMethod.None)
                return new WinState(WinMethod.Draw);

            return winState;
        }                   

        /// <inheritdocs/>
        public IReadOnlyBoardGrid DropValueIntoColumn(BoardSlotValue boardSlotValue, int columnIndex)
        {
            if(IsBoardFull())
                throw new BoardIsFullException();

            if (IsColumnFull(columnIndex))
                throw new ColumnIsFullException(columnIndex);
            
            var firstEmptySlotPosition = GetFirstEmptySlotPositionForColumn(columnIndex);
            SetValueOnPosition(boardSlotValue, firstEmptySlotPosition);            

            return this;
        }        

        /// <summary>
        /// Determines whether a column exists or not.
        /// </summary>
        /// <param name="columnIndex">The 1-based index of the column.</param>        
        private bool DoesColumnIndexExist(int columnIndex)
            => GetExistingColumnIndexes().Contains(columnIndex);

        /// <summary>
        /// Lists the existing column 1-based indexe numbers.
        /// </summary>        
        private List<int> GetExistingColumnIndexes()
            => State
                .Select(slot => slot.Position.Column)
                .Distinct()
                .ToList();

        /// <summary>
        /// Sets the specified <paramref name="boardSlotValue"/> on the given <paramref name="boardPosition"/>.
        /// </summary>
        /// <param name="boardSlotValue">The value to set.</param>
        /// <param name="boardPosition">The position where to set it.</param>
        private void SetValueOnPosition(BoardSlotValue boardSlotValue, BoardPosition boardPosition)
            => _grid[boardPosition.Row - 1, boardPosition.Column - 1] = boardSlotValue;

        /// <summary>
        /// Gets the first valid <see cref="BoardPosition"/> where one can slide a value for a given <paramref name="columnIndex"/>.
        /// </summary>
        /// <param name="columnIndex">The 1-based index of the column.</param>                
        private BoardPosition GetFirstEmptySlotPositionForColumn(int columnIndex)
        {
            if (!DoesColumnIndexExist(columnIndex))
                throw new ColumnDoesntExistException(columnIndex);

            if(IsColumnFull(columnIndex))
                throw new ColumnIsFullException(columnIndex);

            var firstEmptyRowIndex = State
                .Where(slot => slot.Position.Column == columnIndex)
                .Where(slot => slot.Value == BoardSlotValue.Empty)
                .Max(slot => slot.Position.Row);

            return new BoardPosition(firstEmptyRowIndex, columnIndex);
        }        
    }
}
