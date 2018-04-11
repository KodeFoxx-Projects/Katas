namespace Kodefoxx.Katas.FourInARow.Board.Winning.WinStateCalculators
{
    public sealed class DrawWinStateCalculator : WinStateCalculator
    {
        public override WinMethod WinMethod => WinMethod.Draw;
        public override WinStateCalculatorResult Calculate(IBoardGrid boardGrid)
            => NoWinnerResult();        
    }
}
