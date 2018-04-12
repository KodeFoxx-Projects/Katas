using System.Linq;
using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public sealed class RowWinStateCalculator : WinStateCalculator
    {
        public override WinMethod WinMethod => WinMethod.Row;

        public override WinStateCalculatorResult Calculate(IBoardGrid boardGrid)
            => CalculateWinStateCalculatorResultForBoardSlotDictionary(
                boardSlotDictionary: boardGrid.GetBoardSlotRows(),
                orderFunction: boardSlots => boardSlots.OrderBy(slot => slot.Position.Column)
            )
        ;
    }
}
