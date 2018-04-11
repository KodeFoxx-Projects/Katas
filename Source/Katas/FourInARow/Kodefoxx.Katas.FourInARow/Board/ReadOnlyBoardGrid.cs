using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Kodefoxx.Katas.FourInARow.Board.Winning.WinStateCalculators;
using Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators;

namespace Kodefoxx.Katas.FourInARow.Board
{
    public class ReadOnlyBoardGrid : IReadOnlyBoardGrid
    {
        /// <summary>
        /// The internal grid that holds the values/state of the game.
        /// </summary>
        protected readonly BoardSlotValue[,] _grid;

        /// <summary>
        /// The win state calculators loaded.
        /// </summary>
        protected readonly IEnumerable<IWinStateCalculator> _winStateCalculators;

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/>.
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        internal ReadOnlyBoardGrid(int width, int height)
            : this(CreateNewEmptyGridArray(width, height))
        { }

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/>.
        /// </summary>
        /// <param name="boardSize">The size of the board.</param>
        internal ReadOnlyBoardGrid(BoardSize boardSize)
            : this(boardSize.Width, boardSize.Height)
        { }

        /// <summary>
        /// Creates a new <see cref="BoardGrid"/> based on a given set of <see cref="BoardSlotValue"/>.
        /// </summary>
        /// <param name="boardSlotValues"></param>
        internal ReadOnlyBoardGrid(BoardSlotValue[,] boardSlotValues)
        {
            _grid = boardSlotValues;
            _winStateCalculators = GetWinStateCalculators();
        }        

        /// <inheritdocs/>
        public IReadOnlyList<BoardSlot> State
            => _grid
                .ToBoardSlots()
                .ToList()
                .AsReadOnly();

        /// <inheritdocs/>
        public int Rows => _grid.ToBoardSize().Height;

        /// <inheritdocs/>
        public int Columns => _grid.ToBoardSize().Width;

        /// <summary>
        /// Creates a new empty grid array.
        /// </summary>
        /// <param name="width">The width of the grid.</param>
        /// <param name="height">The height of the grid.</param>
        /// <returns></returns>
        private static BoardSlotValue[,] CreateNewEmptyGridArray(int columns, int rows)
        {
            var grid = new BoardSlotValue[rows, columns];
            var gridSize = grid.ToBoardSize();

            for (var rowIndex = 0; rowIndex < gridSize.Height - 1; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < gridSize.Width - 1; columnIndex++)
                    grid[rowIndex, columnIndex] = BoardSlotValue.Empty;
            }

            return grid;
        }

        /// <summary>
        /// Scans the assembly for <see cref="IWinStateCalculator"/> instances.
        /// </summary>        
        private IEnumerable<IWinStateCalculator> GetWinStateCalculators()
            => GetType()
                .Assembly
                .GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract)
                .Where(t => t.IsClass)
                .Where(t => t.GetInterfaces().Contains(typeof(IWinStateCalculator)))
                .Select(t => Activator.CreateInstance(t) as IWinStateCalculator)
                .Where(i => i != null)
                .ToList()
        ;
    }
}
