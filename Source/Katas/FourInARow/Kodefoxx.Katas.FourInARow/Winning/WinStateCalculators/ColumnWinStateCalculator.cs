using System;
using System.Collections.Generic;
using System.Linq;
using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public sealed class ColumnWinStateCalculator : WinStateCalculator
    {
        public override WinMethod WinMethod => WinMethod.Column;
        public override WinStateCalculatorResult Calculate(IBoardGrid boardGrid)
            => CalculateWinStateCalculatorResultForBoardSlotDictionary(
                boardSlotDictionary: boardGrid.GetBoardSlotColumns(),
                orderFunction: boardSlots => boardSlots.OrderBy(slot => slot.Position.Row)
            )
        ;        
    }
}
