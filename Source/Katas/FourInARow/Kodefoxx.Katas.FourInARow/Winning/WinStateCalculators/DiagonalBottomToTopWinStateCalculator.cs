using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public sealed class DiagonalBottomToTopWinStateCalculator : WinStateCalculator
    {
        public override WinMethod WinMethod => WinMethod.DiagonalBottomToTop;

        public override WinStateCalculatorResult Calculate(IBoardGrid boardGrid)
            => CalculateWinStateCalculatorResultForBoardSlotDictionary(
                boardSlotDictionary: boardGrid.GetBoardSlotDiagonalBottomToTopLines()
            )
        ;
    }
}
