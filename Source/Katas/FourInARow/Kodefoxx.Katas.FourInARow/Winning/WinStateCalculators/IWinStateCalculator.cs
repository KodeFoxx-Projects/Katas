﻿using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    /// <summary>
    /// Calculates a win state.
    /// </summary>
    public interface IWinStateCalculator
    {
        /// <summary>
        /// The win method this calculator scans for.
        /// </summary>
        WinMethod WinMethod { get; }

        /// <summary>
        /// Calculates the win state for a grid.
        /// </summary>        
        WinStateCalculatorResult Calculate(IBoardGrid boardGrid);
    }
}
