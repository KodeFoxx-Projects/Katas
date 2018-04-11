using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public abstract class WinStateCalculator : IWinStateCalculator
    {

        /// <inhertidocs/>
        public abstract WinMethod WinMethod { get; }

        /// <inhertidocs/>
        public abstract WinStateCalculatorResult Calculate(IBoardGrid boardGrid);

        /// <summary>
        /// Creates a <see cref="WinStateCalculatorResult"/> based on the defined <see cref="WinMethod"/> without a winner.
        /// </summary>        
        protected WinStateCalculatorResult NoWinnerResult()
            => new WinStateCalculatorResult(WinMethod);

        /// <summary>
        /// Creates a <see cref="WinStateCalculatorResult"/> based on the defined <see cref="WinMethod"/> with the given <paramref name="winner"/>.
        /// </summary>
        /// <param name="winner">The one that has won the game.</param>        
        protected WinStateCalculatorResult WinnerResult(BoardSlotValue winner)
            => new WinStateCalculatorResult(WinMethod, winner);
    }
}
