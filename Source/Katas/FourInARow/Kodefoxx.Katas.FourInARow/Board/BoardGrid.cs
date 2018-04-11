using 
    System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FourInARow.Board.Exceptions;

namespace Kodefoxx.Katas.FourInARow.Board
{
    /// <summary>
    /// Represents the board's 2d grid.
    /// </summary>
    public sealed class BoardGrid : 
        IBoardGrid, 
        IReadOnlyBoardGrid
    {
        private readonly BoardSlotValue[,] _grid;

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/>.
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        internal BoardGrid(int width, int height)
            => _grid = CreateNewEmptyGridArray(width, height);        

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/>.
        /// </summary>
        /// <param name="boardSize">The size of the board.</param>
        internal BoardGrid(BoardSize boardSize) 
            : this(boardSize.Width, boardSize.Height)
        { }

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/> based on a given set of <see cref="BoardSlotValue"/>.
        /// </summary>
        /// <param name="boardSlotValues"></param>
        internal BoardGrid(BoardSlotValue[,] boardSlotValues)
            => _grid = boardSlotValues;        

        /// <inheritdocs/>
        public int Rows => _grid.ToBoardSize().Height;

        /// <inheritdocs/>
        public int Columns => _grid.ToBoardSize().Width;

        /// <inheritdocs/>
        public IReadOnlyList<BoardSlot> State 
            => _grid
                .ToBoardSlots()
                .ToList()
                .AsReadOnly();

        /// <summary>
        /// Creates a new empty grid array.
        /// </summary>
        /// <param name="width">The width of the grid.</param>
        /// <param name="height">The height of the grid.</param>
        /// <returns></returns>
        private BoardSlotValue[,] CreateNewEmptyGridArray(int columns, int rows)
        {
            var grid = new BoardSlotValue[rows, columns];
            var gridSize = grid.ToBoardSize();
            
            for(var rowIndex = 0; rowIndex < gridSize.Height - 1; rowIndex++)
            {
                for(var columnIndex = 0; columnIndex < gridSize.Width - 1; columnIndex++)                
                    grid[rowIndex, columnIndex] = BoardSlotValue.Empty;                
            }            

            return grid;
        }

        /// <inheritdocs/>
        public bool IsColumnFull(int columnIndex)
        {
            if(!DoesColumnIndexExist(columnIndex))
                throw new ColumnDoesntExistException(columnIndex);

            return State
                .Where(slot => slot.Position.Column == columnIndex)
                .All(slot => slot.Value != BoardSlotValue.Empty);
        }         

        private bool DoesColumnIndexExist(int columnIndex)
            => GetExistingColumnIndexes().Contains(columnIndex);

        private List<int> GetExistingColumnIndexes()
            => State
                .Select(slot => slot.Position.Column)
                .Distinct()
                .ToList();

        /// <inheritdocs/>
        public IReadOnlyBoardGrid DropValueIntoColumn(BoardSlotValue boardSlotValue, int columnIndex)
        {
            if (!IsColumnFull(columnIndex))
                throw new ColumnIsFullException(columnIndex);
            
            var firstEmptySlotPosition = GetFirstEmptySlotPositionForColumn(columnIndex);
            SetValueOnPosition(boardSlotValue, firstEmptySlotPosition);            

            return this;
        }

        private void SetValueOnPosition(BoardSlotValue boardSlotValue, BoardPosition boardPosition)
            => _grid[boardPosition.Row - 1, boardPosition.Column - 1] = boardSlotValue;        

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
