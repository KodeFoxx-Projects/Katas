using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public sealed class DiagonalTopToBottomWinStateCalculator : WinStateCalculator
    {
        public override WinMethod WinMethod => WinMethod.DiagonalTop;

        public override WinStateCalculatorResult Calculate(IBoardGrid boardGrid)
            => CalculateWinStateCalculatorResultForBoardSlotDictionary(
                boardSlotDictionary: boardGrid.GetBoardSlotDiagonalTopToBottomLines()
            )
        ;
    }
}
