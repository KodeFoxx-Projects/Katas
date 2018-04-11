using Kodefoxx.Katas.FourInARow.Board;

namespace Kodefoxx.Katas.FourInARow.Winning.WinStateCalculators
{
    public sealed class WinStateCalculatorResult
    {
        /// <summary>
        /// Creates a new <see cref="WinStateCalculatorResult"/>.
        /// </summary>
        /// <param name="method">The method one has one by.</param>
        /// <param name="winner">The winner, if any.</param>
        public WinStateCalculatorResult(WinMethod method, BoardSlotValue? winner = null)
        {
            Method = method;
            Winner = winner;
        }

        /// <summary>
        /// Determines the method one has won by.
        /// </summary>
        public WinMethod Method { get; }

        /// <summary>
        /// Determines the winner, if any.
        /// </summary>
        public BoardSlotValue? Winner { get; }
    }
}
